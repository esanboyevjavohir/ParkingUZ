using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.QRCode;
using ParkingUZ.Application.Models.Reservation;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public ReservationService(IMapper mapper, DataBaseContext dataBaseContext)
        {
            _mapper = mapper;
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ApiResult<CreateReservationResponceModel>> CreateAsync(CreateReservationModel create)
        {
            var createModel = _mapper.Map<Reservation>(create);
            createModel.CreatedOn = DateTime.UtcNow;

            _dataBaseContext.Reservations.Add(createModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<CreateReservationResponceModel>.Success(new CreateReservationResponceModel
            {
                Id = createModel.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var delete = _dataBaseContext.Reservations.FirstOrDefault(x => x.Id == id);
            if (delete == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "ParkingZones not found" });
            }

            _dataBaseContext.Reservations.Remove(delete);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<List<ReservationResponceModel>>> GetAllAsync()
        {
            var getAll = await _dataBaseContext.Reservations
                .AsNoTracking()
                .ProjectTo<ReservationResponceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ApiResult<List<ReservationResponceModel>>.Success(getAll);
        }

        public async Task<ApiResult<ReservationResponceModel>> GetByIdAsync(Guid id)
        {
            var getById = await _dataBaseContext.Reservations
                .AsNoTracking()
                .ProjectTo<ReservationResponceModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (getById == null)
            {
                return ApiResult<ReservationResponceModel>.Failure(
                                new List<string> { "ParkingZones not found" });
            }

            return ApiResult<ReservationResponceModel>.Success(getById);
        }

        public async Task<ApiResult<UpdateReservationResponceModel>> UpdateAsync(Guid id, UpdateReservationModel update)
        {
            var updateModel = await _dataBaseContext.Reservations.FirstOrDefaultAsync(d => d.Id == id);
            if (updateModel == null)
            {
                return ApiResult<UpdateReservationResponceModel>.Failure(new List<string> { "ParkingZone not found" });
            }

            _mapper.Map(update, updateModel);
            updateModel.UpdatedOn = DateTime.UtcNow;
            _dataBaseContext.Reservations.Update(updateModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<UpdateReservationResponceModel>.Success(new UpdateReservationResponceModel
            {
                Id = updateModel.Id
            });
        }
    }
}
