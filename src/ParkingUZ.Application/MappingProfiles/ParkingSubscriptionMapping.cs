using AutoMapper;
using ParkingUZ.Application.Models.ParkingSubscriptionModel;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class ParkingSubscriptionMapping : Profile
    {
        public ParkingSubscriptionMapping()
        {
            CreateMap<CreateParkSubsModel, ParkingSubscription>();

            CreateMap<UpdateParkSubsModel, ParkingSubscription>().ReverseMap();

            CreateMap<ParkingSubscription, ParkingSubscriptionResponceModel>();
        }
    }
}
