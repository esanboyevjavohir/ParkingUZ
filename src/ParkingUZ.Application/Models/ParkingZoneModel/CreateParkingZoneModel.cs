﻿namespace ParkingUZ.Application.Models.ParkingZoneModel
{
    public class CreateParkingZoneModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalSpots { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal XCoordinate { get; set; }
        public decimal YCoordinate { get; set; }
    }
    public class CreateParkingZoneResponceModel : BaseResponseModel { }
}
