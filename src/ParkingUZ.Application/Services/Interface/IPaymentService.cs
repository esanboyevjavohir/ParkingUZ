using ParkingUZ.Application.Models.Payment;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IPaymentService
    {
        Task<PaymentResponceModel> GetByIdAsync(Guid id);
        Task<List<PaymentResponceModel>> GetAllAsync();
        Task<CreatePaymentResponceModel> CreateAsync(CreatePaymentModel create,
            CancellationToken cancellationToken = default);
        Task<UpdatePaymentResponceModel> UpdateAsync(Guid id, UpdatePaymentModel update,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id);
    }
}
