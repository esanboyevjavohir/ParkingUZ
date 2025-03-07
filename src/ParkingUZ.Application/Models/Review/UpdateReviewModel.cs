namespace ParkingUZ.Application.Models.Review
{
    public class UpdateReviewModel
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid ParkingZoneId { get; set; }
    }
    public class UpdateReviewResponceModel : BaseResponceModel { }
}
