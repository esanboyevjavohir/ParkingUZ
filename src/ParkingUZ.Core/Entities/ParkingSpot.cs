using ParkingUZ.Core.Common;
using ParkingUZ.Core.Enums;

namespace ParkingUZ.Core.Entities
{
    public class ParkingSpot : BaseEntity, IAuditedEntity
    {
        public int SpotNumber { get; set; }
        public SpotStatus Status { get; set; } = SpotStatus.Available;
        public decimal PricePerHour { get; set; }
        public Guid ParkingLotId { get; set; }
        public ParkingLot ParkingLot { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
