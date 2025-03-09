using AutoMapper;
using ParkingUZ.Application.Models.Review;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class ReviewMapping : Profile
    {
        public ReviewMapping()
        {
            CreateMap<CreateReviewModel, Review>();

            CreateMap<UpdateReviewModel, Review>().ReverseMap();

            CreateMap<Review, ReviewResponceModel>();
        }
    }
}
