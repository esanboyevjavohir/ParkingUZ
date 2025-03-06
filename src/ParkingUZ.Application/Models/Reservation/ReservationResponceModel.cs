using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.Reservation
{
    public class ReservationResponceModel : BaseResponceModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
