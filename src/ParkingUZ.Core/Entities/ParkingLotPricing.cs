using ParkingUZ.Core.Common;

namespace ParkingUZ.Core.Entities
{
    public class ParkingLotPricing : BaseEntity, IAuditedEntity
    {
        public Guid ParkingLotId { get; set; }
        public ParkingLot ParkingLot { get; set; }
        public Guid PricingPlanId { get; set; }
        public PricingPlan PricingPlan { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
