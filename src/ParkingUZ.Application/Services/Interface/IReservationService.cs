using ParkingUZ.Application.Models.Reservation;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IReservationService
    {
        Task<ReservationResponceModel> GetByIdAsync(Guid id);
        Task<List<ReservationResponceModel>> GetAllAsync();
        Task<CreateReservationResponceModel> CreateAsync(CreateReservationModel create,
            CancellationToken cancellationToken = default);
        Task<UpdateReservationResponceModel> UpdateAsync(Guid id, 
            UpdateReservationModel update, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id);
    }
}
