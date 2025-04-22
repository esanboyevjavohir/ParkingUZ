using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.ReservationModel
{
    public class ReservationResponceModel : BaseResponseModel
    {
        public DateTime StartTime { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public ReservationStatus Status { get; set; }
        public decimal? TotalPaid { get; set; }
    }
}
