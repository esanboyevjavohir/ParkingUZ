using AutoMapper;
using ParkingUZ.Application.Models.ParkingSpot;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.Application.Services.Implement
{
    public class ParkingSpotService : IParkingSpotService
    {
        private readonly IMapper _mapper;
        private readonly IParkingSpotRepository _parkingSpotRepository;

        public ParkingSpotService(IMapper mapper, IParkingSpotRepository parkingSpotRepository)
        {
            _mapper = mapper;
            _parkingSpotRepository = parkingSpotRepository;
        }

        public async Task<ParkingSpotResponceModel> GetByIdAsync(Guid id)
        {
            var parkingSpot = await _parkingSpotRepository.GetFirstAsync(p => p.Id == id);
            if (parkingSpot == null)
                throw new Exception("ParkingSpot not found");

            return _mapper.Map<ParkingSpotResponceModel>(parkingSpot);
        }

        public async Task<List<ParkingSpotResponceModel>> GetAllAsync()
        {
            var res = await _parkingSpotRepository.GetAllAsync(p => true);
            return _mapper.Map<List<ParkingSpotResponceModel>>(res);
        }

        public async Task<CreateParkingSpotResponceModel> CreateAsync(CreateParkingSpotModel create,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<ParkingSpot>(create);

            return new CreateParkingSpotResponceModel
            {
                Id = (await _parkingSpotRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdateParkingSpotResponceModel> UpdateAsync(Guid id,
            UpdateParkingSpotModel update, CancellationToken cancellationToken = default)
        {
            var todoItem = await _parkingSpotRepository.GetFirstAsync(p => p.Id == id);

            _mapper.Map(update, todoItem);
            return new UpdateParkingSpotResponceModel
            {
                Id = (await _parkingSpotRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _parkingSpotRepository.GetFirstAsync(p => p.Id == id);
            if(todoItem == null)
                return false;

            await _parkingSpotRepository.DeleteAsync(todoItem);
            return true;
        }
    }
}
