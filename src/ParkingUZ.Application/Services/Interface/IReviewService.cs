using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.ReviewModel;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IReviewService
    {
        Task<ApiResult<ReviewResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<ReviewResponceModel>>> GetAllAsync();
        Task<ApiResult<CreateReviewResponceModel>> CreateAsync(CreateReviewModel create);
        Task<ApiResult<UpdateReviewResponceModel>> UpdateAsync(Guid id, UpdateReviewModel update);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
    }
}
