using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.ReservationModel;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IReservationService
    {
        Task<ApiResult<ReservationResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<ReservationResponceModel>>> GetAllAsync();
        Task<ApiResult<CreateReservationResponceModel>> CreateAsync(CreateReservationModel create);
        Task<ApiResult<UpdateReservationResponceModel>> UpdateAsync(Guid id, UpdateReservationModel update);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
    }
}
