using AutoMapper;
using ParkingUZ.Application.Models.SubscriptionPlan;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.Application.Services.Implement
{
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;

        public SubscriptionPlanService(IMapper mapper, 
            ISubscriptionPlanRepository subscriptionPlanRepository)
        {
            _mapper = mapper;
            _subscriptionPlanRepository = subscriptionPlanRepository;
        }

        public async Task<CreateSubscriptionResponceModel> CreateAsync(CreateSubscriptionModel create,
            CancellationToken cancellationToken = default)
        {
            var item = _mapper.Map<SubscriptionPlan>(create);

            return new CreateSubscriptionResponceModel
            {
                Id = (await _subscriptionPlanRepository.AddAsync(item)).Id,
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = await _subscriptionPlanRepository.GetFirstAsync(s => s.Id == id);
            if(item == null) return false;

            await _subscriptionPlanRepository.DeleteAsync(item);
            return true;
        }

        public async Task<List<SubscriptionResponceModel>> GetAllAsync()
        {
            var items = await _subscriptionPlanRepository.GetAllAsync(s => true);
            return _mapper.Map<List<SubscriptionResponceModel>>(items); 
        }

        public async Task<SubscriptionResponceModel> GetByIdAsync(Guid id)
        {
            var item = await _subscriptionPlanRepository.GetFirstAsync(s => s.Id == id);
            if (item == null)
                throw new Exception("SubscriptionPlan not found");

            return _mapper.Map<SubscriptionResponceModel>(item);
        }

        public async Task<UpdateSubscriptionResponceModel> UpdateAsync(Guid id, 
            UpdateSubscriptionModel update, CancellationToken cancellationToken = default)
        {
            var item = await _subscriptionPlanRepository.GetFirstAsync(s => s.Id == id);

            _mapper.Map(update, item);

            return new UpdateSubscriptionResponceModel
            {
                Id = (await _subscriptionPlanRepository.UpdateAsync(item)).Id,
            };
        }
    }
}
