using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.Payment
{
    public class UpdatePaymentModel
    {
        public decimal Amount { get; set; }
        public CardType CardType { get; set; }
        public PayStatus PayStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid ReservationId { get; set; }
    }
    public class UpdatePaymentResponceModel : BaseResponceModel { }
}
