namespace ParkingUZ.Application.Models.ParkingZone
{
    public class CreateParkingZoneModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalSpots { get; set; }
        public decimal PricePerHour { get; set; }
        public Guid GeoLocationId { get; set; }
    }
    public class CreateParkingZoneResponceModel : BaseResponseModel { }
}
