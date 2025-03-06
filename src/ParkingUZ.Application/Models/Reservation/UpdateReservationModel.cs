using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.Reservation
{
    public class UpdateReservationModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; }

        public Guid UserId { get; set; }
        public Guid SpotId { get; set; }
        public Guid ParkSubsId { get; set; }
    }
    public class UpdateReservationResponceModel : BaseResponceModel { }
}
