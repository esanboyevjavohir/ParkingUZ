using MediaBrowser.Model.Dto;
using ParkingUZ.Application.DataTransferObject.Authentication;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.User;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IUserService
    {
        Task<ApiResult<UserResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<UserResponceModel>>> GetAllAsync();
        Task<ApiResult<UserResponceModel>> GetUserByEmailAsync(string email);
        Task<ApiResult<CreateUserResponseModel>> SignUpAsync(CreateUserModel userForCreationDTO);
        //Task<User> UpdateUserAsync(Guid id, UpdateUserDTO updateUserDTO);
        Task<ApiResult<LoginResponseModel>> LoginAsync(LoginUserModel loginDTO);
        Task<ApiResult<bool>> DeleteUserAsync(Guid id);    
        Task<bool> VerifyPassword(User user, string password);
    }
}
