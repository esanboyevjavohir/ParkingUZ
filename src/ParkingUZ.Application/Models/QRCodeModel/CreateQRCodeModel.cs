namespace ParkingUZ.Application.Models.QRCodeModel
{
    public class CreateQRCodeModel
    {
        public string QRCodeData { get; set; }
        public DateTime GeneratedAt { get; set; }
        public Guid ReservationId { get; set; }
    }
    public class CreateQRCodeResponceModel : BaseResponseModel { }
}
