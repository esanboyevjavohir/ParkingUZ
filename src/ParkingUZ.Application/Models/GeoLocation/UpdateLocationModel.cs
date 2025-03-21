namespace ParkingUZ.Application.Models.GeoLocation
{
    public class UpdateLocationModel 
    {
        public decimal XCoordinate { get; set; }
        public decimal YCoordinate { get; set; }
    }
    public class UpdateLocationResponseModel : BaseResponseModel { }
}
