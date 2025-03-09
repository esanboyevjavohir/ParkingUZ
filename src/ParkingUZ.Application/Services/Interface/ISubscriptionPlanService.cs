using ParkingUZ.Application.Models.SubscriptionPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingUZ.Application.Services.Interface
{
    public interface ISubscriptionPlanService
    {
        Task<SubscriptionResponceModel> GetByIdAsync(Guid id);
        Task<List<SubscriptionResponceModel>> GetAllAsync();    
        Task<CreateSubscriptionResponceModel> CreateAsync(CreateSubscriptionModel create,
            CancellationToken cancellationToken = default);
        Task<UpdateSubscriptionResponceModel> UpdateAsync(Guid id,
            UpdateSubscriptionModel update, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id);
    }
}
