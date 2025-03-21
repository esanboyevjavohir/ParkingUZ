namespace ParkingUZ.Application.Models.Review
{
    public class CreateReviewModel
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid ParkingZoneId { get; set; }
    }
    public class CreateReviewResponceModel : BaseResponseModel { }
}
