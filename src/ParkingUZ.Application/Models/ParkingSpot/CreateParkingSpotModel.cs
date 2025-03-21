using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.ParkingSpot
{
    public class CreateParkingSpotModel
    {
        public int SpotNumber { get; set; }
        public SpotStatus Status { get; set; } = SpotStatus.Available;
        public Guid ParkingZoneId { get; set; }
    }
    public class CreateParkingSpotResponceModel : BaseResponseModel { }
}
