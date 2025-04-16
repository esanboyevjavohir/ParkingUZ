using ParkingUZ.Application.Models;
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
        Task<ApiResult<DiscountResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<DiscountResponceModel>>> GetAllAsync();
        Task<ApiResult<CreateDiscountResponceModel>> CreateAsync(CreateDiscountModel create);
        Task<ApiResult<UpdateDiscountResponceModel>> UpdateAsync(UpdateDiscountModel update);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
    }
}
