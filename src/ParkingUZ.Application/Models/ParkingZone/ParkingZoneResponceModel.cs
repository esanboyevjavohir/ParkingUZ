namespace ParkingUZ.Application.Models.ParkingZone
{
    public class ParkingZoneResponceModel : BaseResponceModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalSpots { get; set; }
        public decimal PricePerHour { get; set; }
    }
}
