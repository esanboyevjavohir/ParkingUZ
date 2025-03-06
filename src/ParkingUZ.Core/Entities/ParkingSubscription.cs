using ParkingUZ.Core.Common;

namespace ParkingUZ.Core.Entities
{
    public class ParkingSubscription : BaseEntity, IAuditedEntity
    {
        public Guid SubscriptionPlanId { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public Guid ParkingZoneId { get; set; }
        public ParkingZone ParkingZone { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
