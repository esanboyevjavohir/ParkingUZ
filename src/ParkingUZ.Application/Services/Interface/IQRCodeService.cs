using ParkingUZ.Application.Models.QRCode;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IQRCodeService
    {
        Task<QRCodeResponceModel> GetByIdAsync(Guid id);
        Task<List<QRCodeResponceModel>> GetAllAsync();
        Task<CreateQRCodeResponceModel> CreateAsync(CreateQRCodeModel create,
            CancellationToken cancellationToken = default);
        Task<UpdateQRCodeResponceModel> UpdateAsync(Guid id, UpdateQRCodeModel update,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id);
    }
}
