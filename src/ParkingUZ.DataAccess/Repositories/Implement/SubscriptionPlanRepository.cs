using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.DataAccess.Repositories.Implement
{
    public class SubscriptionPlanRepository : BaseRepository<SubscriptionPlan>,
        ISubscriptionPlanRepository
    {
        public SubscriptionPlanRepository(DataBaseContext context) : base(context)
        {
            
        }
    }
}
