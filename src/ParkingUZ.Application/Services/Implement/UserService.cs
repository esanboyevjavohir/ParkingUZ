using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ParkingUZ.Application.DataTransferObject.Authentication;
using ParkingUZ.Application.Helpers.GenerateJwt;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.User;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;
        private readonly IJwtTokenHandler _jwtTokenHandler;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidator<CreateUserModel> _createUserValidator;
        private readonly IValidator<LoginUserModel> _loginValidator;

        public UserService(
            IPasswordHasher passwordHasher, 
            IValidator<CreateUserModel> createUserValidator, 
            IValidator<LoginUserModel> loginValidator)
        {
            _passwordHasher = passwordHasher;
            _createUserValidator = createUserValidator;
            _loginValidator = loginValidator;
        }

        public async Task<ApiResult<CreateUserResponseModel>> SignUpAsync(CreateUserModel userForCreationDTO)
        {
            var validationResult = await _createUserValidator.ValidateAsync(userForCreationDTO);
            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if(userForCreationDTO == null) 
                throw new ArgumentNullException(nameof(userForCreationDTO));

            string randomSalt = Guid.NewGuid().ToString();

            User user = new User()
            {
                Name = userForCreationDTO.Name,
                Email = userForCreationDTO.Email,
                PhoneNumber = userForCreationDTO.PhoneNumber,

                Salt = randomSalt,
                Password = _passwordHasher.Encrypt(
                    password: userForCreationDTO.Password!,
                    salt: randomSalt),
                Role = userForCreationDTO.Role
            };

            var res = await _userRepo.AddAsync(user);
            var result = new UserResponceModel
            {
                Name = userForCreationDTO.Name!,
                Email = userForCreationDTO.Email!,
                PhoneNumber = userForCreationDTO.PhoneNumber!,
                Role = userForCreationDTO.Role
            };

            return res;
        }

        public async Task<ApiResult<LoginResponseModel>> LoginAsync(LoginUserModel loginDTO)
        {
            var validationResult = await _loginValidator.ValidateAsync(loginDTO);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var user = await _userRepo.GetFirstAsync(a => a.Email == loginDTO.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid Email or Password");

            var isPasswordValid = _passwordHasher.Verify(user.Password,
                loginDTO.Password, user.Salt);
            if (!isPasswordValid)
                throw new UnauthorizedAccessException("Invalid Email or Password");

            return MapToDTOLogin(user);
        }

        private LoginResponseModel MapToDTOLogin(User user)
        {
            return new LoginResponseModel()
            {
                Email = user.Email,
                Role = user.Role,
                RefreshToken = user.RefreshToken
            };
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userRepo.GetFirstAsync(u => u.Id == id);
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            await _userRepo.DeleteAsync(user);
            return true;
        }

        public async Task<List<UserResponceModel>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync(u => true);

            return users.Select(a => new UserResponceModel
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
            }).ToList();
        }

        public async Task<UserResponceModel> GetByIdAsync(Guid id)
        {
            var user = await _userRepo.GetFirstAsync(a => a.Id == id);
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            return new UserResponceModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }

        public async Task<UserResponseModel> GetUserByEmailAsync(string email)
        {
            return await _userRepo.GetUserByEmailAsync(email);
        }

        /*public async Task<User> UpdateUserAsync(Guid id, UpdateUserDTO updateUserDTO)
        {
            var validationResult = await _updateUserValidator.ValidateAsync(updateUserDTO);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if(updateUserDTO == null)
                throw new ArgumentNullException(nameof(updateUserDTO), 
                    "updateUserDTO cannot be null");

            var user = await _userRepo.GetFirstAsync(u => u.Id == id);
            if(user == null)
                throw new ArgumentNullException(nameof(user));  

            string randomSalt = Guid.NewGuid().ToString();

            user.Name = updateUserDTO.Name;
            user.Email = updateUserDTO.Email;
            user.PhoneNumber = updateUserDTO.PhoneNumber;
            user.Salt = randomSalt;
            user.Password = _passwordHasher.Encrypt(
                password: updateUserDTO.Password,
                salt: randomSalt);

            await _userRepo.UpdateAsync(user);
            return user;
        }*/

        public async Task<bool> VerifyPassword(User user, string password)
        {
            return await Task.Run(() => user.Password == password); 
        }
    }
}
