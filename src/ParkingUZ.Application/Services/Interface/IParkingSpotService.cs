using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.ParkingSpot;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IParkingSpotService
    {
        Task<ApiResult<ParkingSpotResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<ParkingSpotResponceModel>>> GetAllAsync();
        Task<ApiResult<CreateParkingSpotResponceModel>> CreateAsync(CreateParkingSpotModel create);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
        Task<ApiResult<UpdateParkingSpotResponceModel>> UpdateAsync(Guid id, UpdateParkingSpotModel update);
    }
}
