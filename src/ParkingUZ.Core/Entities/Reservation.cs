using ParkingUZ.Core.Common;
using ParkingUZ.Core.Enums;

namespace ParkingUZ.Core.Entities
{
    public class Reservation : BaseEntity, IAuditedEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public ReservationStatus Status { get; set; }
        public decimal? TotalPaid { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ParkingSpotId { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
        public Guid? ParkingSubscriptionId { get; set; }
        public ParkingSubscription ParkingSubscription { get; set; }

        public List<Payment> Payments = new List<Payment>();
        public List<QRCode> QRCodes = new List<QRCode>();

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
