namespace ParkingUZ.Application.Models.GeoLocation
{
    public class CreateLocationModel
    {
        public decimal XCoordinate { get; set; }
        public decimal YCoordinate { get; set; }
    }
    public class CreateLocationResponseModel : BaseResponseModel { }
}
