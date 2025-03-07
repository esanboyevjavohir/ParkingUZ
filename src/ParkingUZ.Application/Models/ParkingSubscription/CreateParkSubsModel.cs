namespace ParkingUZ.Application.Models.ParkingSubscription
{
    public class CreateParkSubsModel
    {
        public Guid SubscriptionPlanId { get; set; }
        public Guid ParkingZoneId { get; set; }
    }
}
