namespace ParkingUZ.Application.Models.ParkingSubscriptionModel
{
    public class CreateParkSubsModel
    {
        public Guid SubscriptionPlanId { get; set; }
        public Guid ParkingZoneId { get; set; }
    }
    public class CreateParkSubsResponceModel : BaseResponseModel { }
}
