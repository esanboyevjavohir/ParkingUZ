using ParkingUZ.Core.Common;
using ParkingUZ.Core.Enums;

namespace ParkingUZ.Core.Entities
{
    public class SubscriptionPlan : BaseEntity, IAuditedEntity
    {
        public SubscriptionType Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
