using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.Payment
{
    public class PaymentResponceModel : BaseResponceModel
    {
        public decimal Amount { get; set; }
        public CardType CardType { get; set; }
        public PayStatus PayStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
