using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.DataAccess.Repositories.Implement
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(DataBaseContext context) : base(context)
        {
            
        }
    }
}
