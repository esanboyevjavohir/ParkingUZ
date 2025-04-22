using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.Models.ParkingSubscriptionModel
{
    public class ParkingSubscriptionResponceModel : BaseResponseModel
    {
        public Guid SubscriptionPlanId { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public Guid ParkingZoneId { get; set; }
        public ParkingZone ParkingZone { get; set; }
    }
}
