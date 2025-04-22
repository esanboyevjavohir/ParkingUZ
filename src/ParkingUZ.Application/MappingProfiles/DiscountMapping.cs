using AutoMapper;
using ParkingUZ.Application.Models.DiscountModel;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<CreateDiscountModel, Discount>();
            
            CreateMap<UpdateDiscountModel, Discount>().ReverseMap();

            CreateMap<Discount, DiscountResponceModel>();
        }
    }
}
