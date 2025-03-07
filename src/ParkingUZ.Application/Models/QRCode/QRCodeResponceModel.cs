namespace ParkingUZ.Application.Models.QRCode
{
    public class QRCodeResponceModel : BaseResponceModel
    {
        public string QRCodeData { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}
