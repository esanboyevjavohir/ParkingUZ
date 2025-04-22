using MediaBrowser.Model.Dto;
using ParkingUZ.Application.DataTransferObject.Authentication;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.User;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess;
using System.IdentityModel.Tokens.Jwt;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IUserService
    {
        Task<ApiResult<UserResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<UserResponceModel>>> GetAllAsync();
        Task<ApiResult<UserResponceModel>> GetUserByEmailAsync(string email);
        Task<ApiResult<CreateUserResponseModel>> SignUpAsync(CreateUserModel userForCreationDTO);
        Task<ApiResult<bool>> SendOtpCode(Guid userId);
        Task<ApiResult<bool>> ResendOtpCode(Guid userId);
        Task<ApiResult<bool>> VerifyOtpCode(string code, Guid userId);
        Task<ApiResult<LoginResponseModel>> LoginAsync(LoginUserModel loginDTO);
        Task<ApiResult<string>> ValidateAndRefreshToken(Guid id, string refreshToken);
        Task<ApiResult<bool>> ForgotPasswordAsync(string email);
        Task<ApiResult<bool>> ResetPasswordAsync(ResetPasswordModel model);
        Task<ApiResult<bool>> DeleteUserAsync(Guid id);    
    }
}
