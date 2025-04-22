using AutoMapper;
using ParkingUZ.Application.Models.ParkingZoneModel;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class ParkingZoneMapping : Profile
    {
        public ParkingZoneMapping()
        {
            CreateMap<CreateParkingZoneModel, ParkingZone>();

            CreateMap<UpdateParkingZoneModel,  ParkingZone>().ReverseMap();

            CreateMap<ParkingZone, ParkingZoneResponceModel>()
                .ForMember(dest => dest.HasActiveDiscount, opt => opt.MapFrom(src => src.Discount != null 
                    && src.Discount.IsActive));
        }
    }
}
