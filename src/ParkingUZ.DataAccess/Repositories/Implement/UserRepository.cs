using Microsoft.EntityFrameworkCore;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.DataAccess.Repositories.Implement
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public UserRepository(DataBaseContext context) : base(context) { }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dataBaseContext.User.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
