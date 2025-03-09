using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.DataAccess.Repositories.Implement
{
    public class ParkingZoneRepository : BaseRepository<ParkingZone>, IParkingZoneRepository
    {
        public ParkingZoneRepository(DataBaseContext context) : base(context)
        {
            
        }
    }
}
