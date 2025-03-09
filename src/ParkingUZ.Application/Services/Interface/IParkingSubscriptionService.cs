using ParkingUZ.Application.Models.ParkingSubscription;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IParkingSubscriptionService
    {
        Task<ParkingSubscriptionResponceModel> GetByIdAsync(Guid id);
        Task<List<ParkingSubscriptionResponceModel>> GetAllAsync();
        Task<CreateParkSubsResponceModel> CreateAsync(CreateParkSubsModel create,
            CancellationToken cancellationToken = default);
        Task<UpdateParkSubsResponceModel> UpdateAsync(Guid id, UpdateParkSubsModel update,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id);
    }
}
