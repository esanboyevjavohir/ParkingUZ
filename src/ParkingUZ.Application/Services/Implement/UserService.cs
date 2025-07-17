using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ParkingUZ.Application.Helpers;
using ParkingUZ.Application.Helpers.GenerateJwt;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.User;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.Core.Enums;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly DataBaseContext _dataBaseContext;
        private readonly IJwtTokenHandler _jwtTokenHandler;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;
        private readonly UserSettings _userSettings;
        private readonly IValidator<CreateUserModel> _createUserValidator;
        private readonly IValidator<ResetPasswordModel> _resetPasswordValidator;

        public UserService(IConfiguration configuration,
            IMapper mapper,
            ILogger<UserService> logger,
            DataBaseContext dataBaseContext,
            IJwtTokenHandler jwtTokenHandler,
            IPasswordHasher passwordHasher,
            IEmailService emailService,
            IOptions<UserSettings> userSettings, 
            IValidator<CreateUserModel> createUserValidator,
            IValidator<ResetPasswordModel> resetPasswordValidator)
        {
            _mapper = mapper;
            _logger = logger;
            _dataBaseContext = dataBaseContext;
            _jwtTokenHandler = jwtTokenHandler;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
            _userSettings = userSettings.Value;
            _createUserValidator = createUserValidator;
            _resetPasswordValidator = resetPasswordValidator;
        }

        public async Task<ApiResult<CreateUserResponseModel>> SignUpAsync(CreateUserModel createUserModel)
        {
            var validationResult = await _createUserValidator.ValidateAsync(createUserModel);

            if (!validationResult.IsValid)
            {
                return ApiResult<CreateUserResponseModel>
                        .Failure(validationResult.Errors
                            .Select(a => a.ErrorMessage));
            }

            var user = _mapper.Map<User>(createUserModel);

            string randomSalt = Guid.NewGuid().ToString();

            user.Role = UserRole.Candidate;
            user.Salt = randomSalt;
            user.PasswordHash = _passwordHasher.Encrypt(createUserModel.Password, randomSalt);
            user.CreatedOn = DateTime.Now;

            using var transaction = await _dataBaseContext.Database.BeginTransactionAsync();

            try
            {
                await _dataBaseContext.User.AddAsync(user);
                await _dataBaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message, "Error occurred while creating user");
                await transaction.RollbackAsync();
                return ApiResult<CreateUserResponseModel>.Failure(errors: new List<string> { ex.InnerException?.Message });
            }

            await transaction.CommitAsync();

            return ApiResult<CreateUserResponseModel>.Success(new CreateUserResponseModel
            {
                Id = user.Id
            });
        }

        public async Task<ApiResult<bool>> SendOtpCode(Guid userId)
        {
            var maybeUser = await _dataBaseContext.User
            .Include(a => a.OtpCodes)
            .FirstOrDefaultAsync(a => a.Id == userId);

            if (maybeUser == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "User not found" });
            }

            var otpCode = new OtpCode
            {
                Code = OtpCodeHelper.GenerateOtpCode(),
                Status = OtpCodeStatus.Unverified
            };

            maybeUser.OtpCodes.Add(otpCode);

            bool isSent = await _emailService.SendEmailAsync(maybeUser.Email, otpCode.Code);

            if (!isSent)
            {
                return ApiResult<bool>.Failure(new List<string> { "Failed to send OTP email" });
            }

            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<bool>> ResendOtpCode(Guid userId)
        {
            var user = await _dataBaseContext.User.Include(a => a.OtpCodes)
            .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "User not found" });
            }

            var lastOtp = user.OtpCodes
                .OrderByDescending(otp => otp.CreatedAt)
                .FirstOrDefault();

            if (lastOtp == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "No OTP found to resend" });
            }

            if (!CanResend(lastOtp.CreatedAt))
            {
                var waitTimeSeconds = GetWaitTimeForResend(lastOtp.CreatedAt);
                return ApiResult<bool>.Failure(new List<string>
                { $"Please wait {waitTimeSeconds} seconds before requesting a new code" });
            }

            if (!IsExpired(lastOtp.CreatedAt))
            {
                bool isSent = await _emailService.SendEmailAsync(user.Email, lastOtp.Code);
                if (!isSent)
                {
                    return ApiResult<bool>.Failure(new List<string> { "Failed to send OTP email" });
                }
                return ApiResult<bool>.Success(true);
            }

            var newOtpCode = new OtpCode
            {
                Code = OtpCodeHelper.GenerateOtpCode(),
                Status = OtpCodeStatus.Unverified
            };

            user.OtpCodes.Add(newOtpCode);

            bool isSentNew = await _emailService.SendEmailAsync(user.Email, newOtpCode.Code);
            if (!isSentNew)
            {
                return ApiResult<bool>.Failure(new List<string> { "Failed to send OTP email" });
            }

            await _dataBaseContext.SaveChangesAsync();
            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<bool>> VerifyOtpCode(string code, Guid userId)
        {
            if (string.IsNullOrEmpty(code))
            {
                return ApiResult<bool>.Failure(new List<string> { "OTP code cannot be empty" });
            }

            var user = await _dataBaseContext.User
                .Include(o => o.OtpCodes)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "User not found" });
            }

            var lastOtp = user.OtpCodes
                .Where(otp => otp.Status == OtpCodeStatus.Unverified)
                .OrderByDescending(otp => otp.CreatedAt)
                .FirstOrDefault();

            if (lastOtp == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "No active OTP found" });
            }

            if (IsExpired(lastOtp.CreatedAt))
            {
                lastOtp.Status = OtpCodeStatus.Expired;
                await _dataBaseContext.SaveChangesAsync();
                return ApiResult<bool>.Failure(new List<string> { "OTP has expired" });
            }

            if (lastOtp.Code != code)
            {
                return ApiResult<bool>.Failure(new List<string> { "Invalid OTP code" });
            }

            lastOtp.Status = OtpCodeStatus.Verified;
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<string>> ValidateAndRefreshToken(Guid id, string refreshToken)
        {
            var user = await _dataBaseContext.User.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return ApiResult<string>.Failure(new List<string> { "User not found" });
            }

            if (user.RefreshToken != refreshToken)
            {
                return ApiResult<string>.Failure(new List<string> { "Invalid refresh token" });
            }

            if (user.RefreshTokenExpireDate < DateTime.Now)
            {
                return ApiResult<string>.Failure(new List<string> { "Unauthorized" });
            }

            return ApiResult<string>.Success(_jwtTokenHandler.GenerateAccesToken(user, refreshToken));
        }

        public async Task<ApiResult<bool>> ForgotPasswordAsync(string email)
        {
            var user = await _dataBaseContext.User.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            { 
                return ApiResult<bool>.Failure(new List<string> { "User not found" });
            }

            string tempPassword = GenerateTemporaryPassword();
            user.ResetPasswordToken = _passwordHasher.Encrypt(tempPassword, user.Salt);
            user.ResetPasswordTokenExpiry = DateTime.UtcNow.AddMinutes(10);

            await _dataBaseContext.SaveChangesAsync();

            bool emailSent = await _emailService.SendEmailAsync(user.Email, $"Your temporary password: {tempPassword}");

            return emailSent ? ApiResult<bool>.Success(true) : ApiResult<bool>.Failure(new List<string> { "Failed to send email" });
        }
        private string GenerateTemporaryPassword()
        {
            return new Random().Next(100000, 999999).ToString();
        }

        public async Task<ApiResult<bool>> ResetPasswordAsync(ResetPasswordModel model)
        {
            var validationResult = await _resetPasswordValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return ApiResult<bool>
                        .Failure(validationResult.Errors
                            .Select(a => a.ErrorMessage));
            }

            var user = await _dataBaseContext.User.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "User not found" });
            }

            if (user.ResetPasswordTokenExpiry < DateTime.UtcNow)
            {
                return ApiResult<bool>.Failure(new List<string> { "Temporary password expired" });
            }

            if (user.ResetPasswordToken != _passwordHasher.Encrypt(model.TemporaryPassword, user.Salt))
            {
                return ApiResult<bool>.Failure(new List<string> { "Invalid temporary password" });
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                return ApiResult<bool>.Failure(new List<string> { "Passwords do not match" });
            }

            user.PasswordHash = _passwordHasher.Encrypt(model.NewPassword, user.Salt);
            user.ResetPasswordToken = null;
            user.ResetPasswordTokenExpiry = null;

            await _dataBaseContext.SaveChangesAsync();
            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<LoginResponseModel>> LoginAsync(LoginUserModel loginModel)
        {
            var user = await _dataBaseContext.User.FirstOrDefaultAsync(u => u.Email == loginModel.Email);
            if (user == null)
            {
                return ApiResult<LoginResponseModel>.Failure(new List<string> { "User not found" });
            }

            var hashedPassword = _passwordHasher.Encrypt(loginModel.Password, user.Salt);
            if (user.PasswordHash != hashedPassword)
            {
                return ApiResult<LoginResponseModel>.Failure(new List<string> { "Invalid password" });
            }

            var accessToken = _jwtTokenHandler.GenerateAccesToken(user);
            var refreshToken = _jwtTokenHandler.GenerateRefreshToken();

            user.CreatedOn = DateTime.Now;
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpireDate = DateTime.Now.AddDays(_userSettings.RefreshTokenExpirationDays);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<LoginResponseModel>.Success(new LoginResponseModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Email = user.Email,
                Id = user.Id
            });
        }

        public async Task<ApiResult<UserResponceModel>> GetByIdAsync(Guid id)
        {
            var user = await _dataBaseContext.User
                .AsNoTracking()
                .ProjectTo<UserResponceModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return ApiResult<UserResponceModel>.Failure(new List<string> { "User not found" });
            }

            return ApiResult<UserResponceModel>.Success(user);
        }

        public async Task<ApiResult<List<UserResponceModel>>> GetAllAsync()
        {
            var users = await _dataBaseContext.User.AsNoTracking()
                .ProjectTo<UserResponceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ApiResult<List<UserResponceModel>>.Success(users);
        }

        public async Task<ApiResult<UserResponceModel>> GetUserByEmailAsync(string email)
        {
            var user = await _dataBaseContext.User
                .AsNoTracking()
                .ProjectTo<UserResponceModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Email == email);

            if (user == null)
            {
                return ApiResult<UserResponceModel>.Failure(new List<string> { "User not found" });
            }

            return ApiResult<UserResponceModel>.Success(user);
        }

        public async Task<ApiResult<bool>> DeleteUserAsync(Guid id)
        {
            var user = await _dataBaseContext.User.FirstOrDefaultAsync(e => e.Id == id);
            if (user == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "User not found" });
            }

            _dataBaseContext.User.Remove(user);
            await _dataBaseContext.SaveChangesAsync();  

            return ApiResult<bool>.Success(true);
        }

        public bool IsExpired(DateTimeOffset createdAt) =>
            createdAt.AddSeconds(_userSettings.OtpExpirationTimeInSeconds) < DateTimeOffset.Now;

        private bool CanResend(DateTimeOffset createdAt) =>
            createdAt.AddSeconds(_userSettings.OtpExpirationTimeInSeconds - _userSettings.OtpResendTimeInSeconds) < DateTimeOffset.Now;

        private int GetWaitTimeForResend(DateTimeOffset createdAt)
        {
            var resendTime = createdAt.AddSeconds(_userSettings.OtpExpirationTimeInSeconds - _userSettings.OtpResendTimeInSeconds);
            var waitTime = resendTime - DateTimeOffset.Now;
            return Math.Max(0, (int)waitTime.TotalSeconds);
        }
    }
}
