using AutoMapper;
using ParkingUZ.Application.Models.ParkingSpotModel;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class ParkingSpotMapping : Profile
    {
        public ParkingSpotMapping()
        {
            CreateMap<CreateParkingSpotModel, ParkingSpot>();
    
            CreateMap<UpdateParkingSpotModel, ParkingSpot>().ReverseMap();

            CreateMap<ParkingSpot, ParkingSpotResponceModel>();
        }
    }
}
