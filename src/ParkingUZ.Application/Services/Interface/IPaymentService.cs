using Microsoft.AspNetCore.Http;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.Payment;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IPaymentService
    {
        Task<ApiResult<PaymentResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<PaymentResponceModel>>> GetAllAsync();
        Task<ApiResult<CreatePaymentResponceModel>> CreateAsync(CreatePaymentModel create);
        Task<ApiResult<UpdatePaymentResponceModel>> UpdateAsync(Guid id, UpdatePaymentModel update);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
    }
}
