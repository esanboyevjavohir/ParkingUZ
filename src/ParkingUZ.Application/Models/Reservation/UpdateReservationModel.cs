using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.Reservation
{
    public class UpdateReservationModel
    {
        public DateTime StartTime { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public ReservationStatus Status { get; set; }
        public decimal? TotalPaid { get; set; }

        public Guid UserId { get; set; }
        public Guid ParkingSpotId { get; set; }
        public Guid ParkingSubscriptionId { get; set; }
    }
    public class UpdateReservationResponceModel : BaseResponseModel { }
}
