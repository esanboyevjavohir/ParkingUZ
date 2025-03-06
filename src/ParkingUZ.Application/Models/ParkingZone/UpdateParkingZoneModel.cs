namespace ParkingUZ.Application.Models.ParkingZone
{
    public class UpdateParkingZoneModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalSpots { get; set; }
        public decimal PricePerHour { get; set; }
    }
    public class UpdateParkingZoneResponceModel : BaseResponceModel { }
}
