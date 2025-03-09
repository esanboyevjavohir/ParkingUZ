using ParkingUZ.Application.Models.ParkingSpot;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IParkingSpotService
    {
        Task<ParkingSpotResponceModel> GetByIdAsync(Guid id);
        Task<List<ParkingSpotResponceModel>> GetAllAsync();
        Task<CreateParkingSpotResponceModel> CreateAsync(CreateParkingSpotModel create,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id);
        Task<UpdateParkingSpotResponceModel> UpdateAsync(Guid id,
            UpdateParkingSpotModel update, CancellationToken cancellationToken = default);
    }
}
