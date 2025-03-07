using AutoMapper;
using ParkingUZ.Application.Models.ParkingSubscription;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class ParkingSubscriptionMapping : Profile
    {
        public ParkingSubscriptionMapping()
        {
            CreateMap<CreateParkSubsModel, ParkingSubscription>();

            CreateMap<UpdateParkSubsModel, ParkingSubscription>().ReverseMap();
        }
    }
}
