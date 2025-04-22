using AutoMapper;
using ParkingUZ.Application.Models.ReservationModel;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class ReservationMapping : Profile
    {
        public ReservationMapping()
        {
            CreateMap<CreateReservationModel, Reservation>();
         
            CreateMap<UpdateReservationModel, Reservation>().ReverseMap();

            CreateMap<Reservation, ReservationResponceModel>();
        }
    }
}
