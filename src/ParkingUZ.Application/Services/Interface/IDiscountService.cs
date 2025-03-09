using ParkingUZ.Application.Models.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IDiscountService
    {
        Task<DiscountResponceModel> GetByIdAsync(Guid id);
        Task<List<DiscountResponceModel>> GetAllAsync();
        Task<CreateDiscountResponceModel> CreateAsync(CreateDiscountModel create,
            CancellationToken cancellationToken = default);
        Task<UpdateDiscountResponceModel> UpdateAsync(Guid id, UpdateDiscountModel update,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id);
    }
}
