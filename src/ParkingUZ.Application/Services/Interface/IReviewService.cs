using ParkingUZ.Application.Models.Review;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IReviewService
    {
        Task<ReviewResponceModel> GetByIdAsync(Guid id);
        Task<List<ReviewResponceModel>> GetAllAsync();
        Task<CreateReviewResponceModel> CreateAsync(CreateReviewModel create,
            CancellationToken cancellationToken = default);
        Task<UpdateReviewResponceModel> UpdateAsync(Guid id, UpdateReviewModel update,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id);
    }
}
