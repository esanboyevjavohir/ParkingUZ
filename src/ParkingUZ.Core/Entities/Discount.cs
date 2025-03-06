using ParkingUZ.Core.Common;

namespace ParkingUZ.Core.Entities
{
    public class Discount : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ParkingZoneId { get; set; }
        public ParkingZone ParkingZone { get; set; }
        public bool IsActive => DateTime.UtcNow >= StartDate
            && DateTime.UtcNow <= EndDate;

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
