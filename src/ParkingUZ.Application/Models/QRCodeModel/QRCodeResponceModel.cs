namespace ParkingUZ.Application.Models.QRCodeModel
{
    public class QRCodeResponceModel : BaseResponseModel
    {
        public string QRCodeData { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}
