using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.QRCodeModel;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IQRCodeService
    {
        Task<ApiResult<QRCodeResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<QRCodeResponceModel>>> GetAllAsync();
        Task<ApiResult<CreateQRCodeResponceModel>> CreateAsync(CreateQRCodeModel create);
        Task<ApiResult<UpdateQRCodeResponceModel>> UpdateAsync(Guid id, UpdateQRCodeModel update);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
    }
}
