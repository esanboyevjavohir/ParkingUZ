using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.SubscriptionPlanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingUZ.Application.Services.Interface
{
    public interface ISubscriptionPlanService
    {
        Task<ApiResult<SubscriptionResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<SubscriptionResponceModel>>> GetAllAsync();    
        Task<ApiResult<CreateSubscriptionResponceModel>> CreateAsync(CreateSubscriptionModel create);
        Task<ApiResult<UpdateSubscriptionResponceModel>> UpdateAsync(Guid id, UpdateSubscriptionModel update);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
    }
}
