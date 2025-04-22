namespace ParkingUZ.Application.Models.ParkingSubscriptionModel
{
    public class UpdateParkSubsModel
    {
        public Guid SubscriptionPlanId { get; set; }
        public Guid ParkingZoneId { get; set; }
    }
    public class UpdateParkSubsResponceModel : BaseResponseModel { }
}
