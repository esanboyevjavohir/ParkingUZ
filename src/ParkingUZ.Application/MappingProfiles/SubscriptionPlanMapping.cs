using AutoMapper;
using ParkingUZ.Application.Models.SubscriptionPlan;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class SubscriptionPlanMapping : Profile
    {
        public SubscriptionPlanMapping()
        {
            CreateMap<CreateSubscriptionModel, SubscriptionPlan>();

            CreateMap<UpdateSubscriptionModel, SubscriptionPlan>();

            CreateMap<SubscriptionPlan, SubscriptionResponceModel>();
        }
    }
}
