using ParkingUZ.Core.Common;
using ParkingUZ.Core.Enums;

namespace ParkingUZ.Core.Entities
{
    public class ParkingLot : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public int TotalSpots { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
