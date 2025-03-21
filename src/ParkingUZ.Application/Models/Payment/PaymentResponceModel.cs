using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.Payment
{
    public class PaymentResponceModel : BaseResponseModel
    {
        public decimal Amount { get; set; }
        public PaymentType CardType { get; set; }
        public PayStatus PayStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
