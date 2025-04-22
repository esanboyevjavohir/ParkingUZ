using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.PaymentModel
{
    public class UpdatePaymentModel
    {
        public decimal Amount { get; set; }
        public PaymentType CardType { get; set; }
        public PayStatus PayStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid ReservationId { get; set; }
    }
    public class UpdatePaymentResponceModel : BaseResponseModel { }
}
