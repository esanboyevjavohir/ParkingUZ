using AutoMapper;
using ParkingUZ.Application.Models.PaymentModel;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class PaymentMapping : Profile
    {
        public PaymentMapping()
        {
            CreateMap<CreatePaymentModel, Payment>();

            CreateMap<UpdatePaymentModel, Payment>().ReverseMap();

            CreateMap<Payment, PaymentResponceModel>();
        }
    }
}
