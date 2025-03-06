using ParkingUZ.Core.Common;

namespace ParkingUZ.Core.Entities
{
    public class QRCode : BaseEntity, IAuditedEntity
    {
        public string QRCodeData { get; set; }
        public DateTime GeneratedAt { get; set; }
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
