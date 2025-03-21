namespace ParkingUZ.Application.Models.ParkingSubscription
{
    public class ParkingSubscriptionResponceModel : BaseResponseModel
    {
        public Guid SubscriptionPlanId { get; set; }
        public Guid ParkingZoneId { get; set; }
    }
}
