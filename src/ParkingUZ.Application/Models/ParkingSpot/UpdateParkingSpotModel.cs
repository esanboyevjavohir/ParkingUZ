using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.ParkingSpot
{
    public class UpdateParkingSpotModel
    {
        public int SpotNumber { get; set; }
        public SpotStatus Status { get; set; }
        public Guid ParkingZoneId { get; set; }
    }
    public class UpdateParkingSpotResponceModel : BaseResponseModel { }
}
