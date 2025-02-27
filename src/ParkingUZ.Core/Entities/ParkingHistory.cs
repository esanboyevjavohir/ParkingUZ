using ParkingUZ.Core.Common;

namespace ParkingUZ.Core.Entities
{
    public class ParkingHistory : BaseEntity, IAuditedEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ParkingLotId { get; set; }
        public ParkingLot ParkingLot { get; set; }
        public Guid SpotId { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public decimal TotalPaid { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
