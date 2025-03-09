namespace ParkingUZ.Application.Models.ParkingSubscription
{
    public class ParkingSubscriptionResponceModel : BaseResponceModel
    {
        public Guid SubscriptionPlanId { get; set; }
        public Guid ParkingZoneId { get; set; }
    }
}
