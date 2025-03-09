using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.DataAccess.Repositories.Implement
{
    public class QRCodeRepository : BaseRepository<QRCode>, IQRCodeRepository
    {
        public QRCodeRepository(DataBaseContext context) : base(context)
        {
            
        }
    }
}
