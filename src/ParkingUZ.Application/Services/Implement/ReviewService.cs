using AutoMapper;
using ParkingUZ.Application.Models.Review;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.Application.Services.Implement
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public async Task<CreateReviewResponceModel> CreateAsync(CreateReviewModel create, 
            CancellationToken cancellationToken = default)
        {
            var item = _mapper.Map<Review>(create);

            return new CreateReviewResponceModel
            {
                Id = (await _reviewRepository.AddAsync(item)).Id,
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var res = await _reviewRepository.GetFirstAsync(r => r.Id == id);
            if(res == null) return false;

            await _reviewRepository.DeleteAsync(res);
            return true;
        }

        public async Task<List<ReviewResponceModel>> GetAllAsync()
        {
            var res = await _reviewRepository.GetAllAsync(r => true);

            return _mapper.Map<List<ReviewResponceModel>>(res); 
        }

        public async Task<ReviewResponceModel> GetByIdAsync(Guid id)
        {
            var item = await _reviewRepository.GetFirstAsync(r => r.Id == id);
            if (item == null)
                throw new Exception("Review not found");

            return _mapper.Map<ReviewResponceModel>(item);
        }

        public async Task<UpdateReviewResponceModel> UpdateAsync(Guid id,
            UpdateReviewModel update, CancellationToken cancellationToken = default)
        {
            var item = await _reviewRepository.GetFirstAsync(r => r.Id == id);

            _mapper.Map(update, item);

            return new UpdateReviewResponceModel
            {
                Id = (await _reviewRepository.UpdateAsync(item)).Id
            };
        }
    }
}
