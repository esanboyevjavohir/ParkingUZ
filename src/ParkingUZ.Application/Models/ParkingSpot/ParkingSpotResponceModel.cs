using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.ParkingSpot
{
    public class ParkingSpotResponceModel : BaseResponceModel
    {
        public int SpotNumber { get; set; }
        public SpotStatus Status { get; set; }
    }
}
