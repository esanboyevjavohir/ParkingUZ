using AutoMapper;
using ParkingUZ.Application.Models.ParkingSubscription;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.Application.Services.Implement
{
    public class ParkingSubscriptionService : IParkingSubscriptionService
    {
        private readonly IMapper _mapper;
        private readonly IParkingSubscriptionRepository _parkingSubscriptionRepository;

        public ParkingSubscriptionService(IMapper mapper, 
            IParkingSubscriptionRepository parkingSubscriptionRepository)
        {
            _mapper = mapper;
            _parkingSubscriptionRepository = parkingSubscriptionRepository;
        }

        public async Task<CreateParkSubsResponceModel> CreateAsync(CreateParkSubsModel create,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<ParkingSubscription>(create);

            return new CreateParkSubsResponceModel
            {
                Id = (await _parkingSubscriptionRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _parkingSubscriptionRepository.GetFirstAsync(p => p.Id == id);
            if(todoItem == null)
                return false;

            await _parkingSubscriptionRepository.DeleteAsync(todoItem);
            return true;
        }

        public async Task<List<ParkingSubscriptionResponceModel>> GetAllAsync()
        {
            var res = await _parkingSubscriptionRepository.GetAllAsync(p => true);
            return _mapper.Map<List<ParkingSubscriptionResponceModel>>(res);
        }

        public async Task<ParkingSubscriptionResponceModel> GetByIdAsync(Guid id)
        {
            var parkSubs = await _parkingSubscriptionRepository.GetFirstAsync(p => p.Id == id);
            if (parkSubs == null)
                throw new Exception("ParkingSubs not found");

            return _mapper.Map<ParkingSubscriptionResponceModel>(parkSubs);
        }

        public async Task<UpdateParkSubsResponceModel> UpdateAsync(Guid id, 
            UpdateParkSubsModel update, CancellationToken cancellationToken = default)
        {
            var todoItem = await _parkingSubscriptionRepository.GetFirstAsync(p => p.Id == id);
            
            _mapper.Map(update, todoItem);

            return new UpdateParkSubsResponceModel
            {
                Id = (await _parkingSubscriptionRepository.UpdateAsync(todoItem)).Id
            };
        }
    }
}
