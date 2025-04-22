using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.SubscriptionPlanModel
{
    public class SubscriptionResponceModel : BaseResponseModel
    {
        public SubscriptionType Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
