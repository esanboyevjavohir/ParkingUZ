using AutoMapper;
using ParkingUZ.Application.Models.ParkingZone;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class ParkingZoneMapping : Profile
    {
        public ParkingZoneMapping()
        {
            CreateMap<CreateParkingZoneModel, ParkingZone>();

            CreateMap<UpdateParkingZoneModel,  ParkingZone>().ReverseMap();

            CreateMap<ParkingZone, ParkingZoneResponceModel>();
        }
    }
}
