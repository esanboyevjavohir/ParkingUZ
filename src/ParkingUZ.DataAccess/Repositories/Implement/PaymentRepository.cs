using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.DataAccess.Repositories.Implement
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DataBaseContext context) : base(context)
        {
            
        }
    }
}
