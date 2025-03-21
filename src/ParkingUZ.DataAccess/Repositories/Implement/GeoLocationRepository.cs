using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.DataAccess.Repositories.Implement
{
    public class GeoLocationRepository : BaseRepository<GeoLocation>, IGeoLocationRepository
    {
        public GeoLocationRepository(DataBaseContext context) : base(context)
        {
            
        }
    }
}
