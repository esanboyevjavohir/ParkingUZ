using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.DataAccess.Repositories.Implement
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(DataBaseContext context) : base(context) 
        {
            
        }
    }
}
