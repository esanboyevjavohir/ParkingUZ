using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.ParkingSubscription;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IParkingSubscriptionService
    {
        Task<ApiResult<ParkingSubscriptionResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<ParkingSubscriptionResponceModel>>> GetAllAsync();
        Task<ApiResult<CreateParkSubsResponceModel>> CreateAsync(CreateParkSubsModel create);
        Task<ApiResult<UpdateParkSubsResponceModel>> UpdateAsync(Guid id, UpdateParkSubsModel update);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
    }
}
