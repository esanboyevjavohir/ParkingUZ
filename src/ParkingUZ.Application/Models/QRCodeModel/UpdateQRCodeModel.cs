namespace ParkingUZ.Application.Models.QRCodeModel
{
    public class UpdateQRCodeModel
    {
        public string QRCodeData { get; set; }
        public DateTime GeneratedAt { get; set; }
        public Guid ReservationId { get; set; }
    }
    public class UpdateQRCodeResponceModel : BaseResponseModel { }
}
