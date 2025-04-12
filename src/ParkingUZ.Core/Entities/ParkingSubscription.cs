using ParkingUZ.Core.Common;

namespace ParkingUZ.Core.Entities
{
    public class ParkingSubscription : BaseEntity, IAuditedEntity
    {
        public Guid SubscriptionPlanId { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public Guid ParkingZoneId { get; set; }
        public ParkingZone ParkingZone { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
