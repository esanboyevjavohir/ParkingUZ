using MediaBrowser.Model.Dto;
using ParkingUZ.Application.DataTransferObject.Authentication;
using ParkingUZ.Application.DTO;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IUserService
    {
        Task<UserResponceDTO> GetByIdAsync(Guid id);
        Task<List<UserResponceDTO>> GetAllAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(UserForCreationDTO userForCreationDTO);
        Task<User> UpdateUserAsync(Guid id, UpdateUserDTO updateUserDTO);
        Task<AuthorizationUserDTO> AuthenticateAsync(LoginDTO loginDTO);
        Task<bool> DeleteUserAsync(Guid id);    
        Task<bool> VerifyPassword(User user, string password);
    }
}
