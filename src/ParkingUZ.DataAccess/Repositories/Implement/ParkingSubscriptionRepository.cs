using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.DataAccess.Repositories.Implement
{
    public class ParkingSubscriptionRepository : BaseRepository<ParkingSubscription>,
        IParkingSubscriptionRepository
    {
        public ParkingSubscriptionRepository(DataBaseContext context) : base(context)
        {
            
        }
    }
}
