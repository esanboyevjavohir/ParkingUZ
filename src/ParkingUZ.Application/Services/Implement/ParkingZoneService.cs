using AutoMapper;
using ParkingUZ.Application.Models.ParkingZone;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.Application.Services.Implement
{
    public class ParkingZoneService : IParkingZoneService
    {
        private readonly IMapper _mapper;
        private readonly IParkingZoneRepository _parkingZoneRepository;

        public ParkingZoneService(IMapper mapper, 
            IParkingZoneRepository parkingZoneRepository)
        {
            _mapper = mapper;
            _parkingZoneRepository = parkingZoneRepository;
        }

        public async Task<CreateParkingZoneResponceModel> CreateAsync(CreateParkingZoneModel create,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<ParkingZone>(create);

            return new CreateParkingZoneResponceModel
            {
                Id = (await _parkingZoneRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var res = await _parkingZoneRepository.GetFirstAsync(p => p.Id == id);
            if(res == null) return false;

            await _parkingZoneRepository.DeleteAsync(res);
            return true;
        }

        public async Task<List<ParkingZoneResponceModel>> GetAllAsync()
        {
            var res = await _parkingZoneRepository.GetAllAsync(p => true);
            return _mapper.Map<List<ParkingZoneResponceModel>>(res);    
        }

        public async Task<ParkingZoneResponceModel> GetByIdAsync(Guid id)
        {
            var todoItem = await _parkingZoneRepository.GetFirstAsync(p => p.Id == id);
            if (todoItem == null)
                throw new Exception("ParkingZone not found");

            return _mapper.Map<ParkingZoneResponceModel>(todoItem);
        }

        public async Task<UpdateParkingZoneResponceModel> UpdateAsync(Guid id, 
            UpdateParkingZoneModel update, CancellationToken cancellationToken = default)
        {
            var todoItem = await _parkingZoneRepository.GetFirstAsync(p=> p.Id == id);
            
            _mapper.Map(update, todoItem);

            return new UpdateParkingZoneResponceModel
            {
                Id = (await _parkingZoneRepository.UpdateAsync(todoItem)).Id
            };
        }
    }
}
