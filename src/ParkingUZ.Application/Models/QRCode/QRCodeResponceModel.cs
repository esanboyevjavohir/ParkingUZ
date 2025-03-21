namespace ParkingUZ.Application.Models.QRCode
{
    public class QRCodeResponceModel : BaseResponseModel
    {
        public string QRCodeData { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}
