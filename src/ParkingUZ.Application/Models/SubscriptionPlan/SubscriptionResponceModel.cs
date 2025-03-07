using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.SubscriptionPlan
{
    public class SubscriptionResponceModel : BaseResponceModel
    {
        public SubscriptionType Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
