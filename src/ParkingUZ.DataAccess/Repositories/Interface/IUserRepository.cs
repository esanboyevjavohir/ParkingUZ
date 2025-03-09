using ParkingUZ.Core.Entities;

namespace ParkingUZ.DataAccess.Repositories.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
