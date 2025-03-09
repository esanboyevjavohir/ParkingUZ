using AutoMapper;
using ParkingUZ.Application.Models.Reservation;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.Application.Services.Implement
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IMapper mapper, 
            IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        public async Task<CreateReservationResponceModel> CreateAsync(CreateReservationModel create,
            CancellationToken cancellationToken = default)
        {
            var item = _mapper.Map<Reservation>(create);

            return new CreateReservationResponceModel
            {
                Id = (await _reservationRepository.AddAsync(item)).Id,
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var res = await _reservationRepository.GetFirstAsync(r=> r.Id == id);
            if (res == null) return false;

            await _reservationRepository.DeleteAsync(res);
            return true;
        }

        public async Task<List<ReservationResponceModel>> GetAllAsync()
        {
            var items = await _reservationRepository.GetAllAsync(r => true);

            return _mapper.Map<List<ReservationResponceModel>>(items);
        }

        public async Task<ReservationResponceModel> GetByIdAsync(Guid id)
        {
            var item = await _reservationRepository.GetFirstAsync(r => r.Id == id);
            if (item == null)
                throw new Exception("Reservation not found");

            return _mapper.Map<ReservationResponceModel>(item);
        }

        public async Task<UpdateReservationResponceModel> UpdateAsync(Guid id, 
            UpdateReservationModel update, CancellationToken cancellationToken = default)
        {
            var item = await _reservationRepository.GetFirstAsync(r => r.Id == id);

            _mapper.Map(update, item);

            return new UpdateReservationResponceModel
            {
                Id = (await _reservationRepository.UpdateAsync(item)).Id,
            };
        }
    }
}
