using AutoMapper;
using ParkingUZ.Application.Models.User;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, User>().ReverseMap();
            CreateMap<ForgotPasswordModel, User>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<ResetPasswordModel, User>()
             .ForMember(dest => dest.ResetPasswordToken, opt => opt.MapFrom(src => src.Email))
             .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<User, UserResponceModel>();
        }
    }
}
