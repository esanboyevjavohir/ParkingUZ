using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.ParkingSubscriptionModel;
using ParkingUZ.Application.Models.ParkingZoneModel;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class ParkingZoneService : IParkingZoneService
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public ParkingZoneService(IMapper mapper, DataBaseContext dataBaseContext)
        {
            _mapper = mapper;
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ApiResult<CreateParkingZoneResponceModel>> CreateAsync(CreateParkingZoneModel create)
        {
            var createModel = _mapper.Map<ParkingZone>(create);
            createModel.CreatedOn = DateTime.UtcNow;

            _dataBaseContext.ParkingZones.Add(createModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<CreateParkingZoneResponceModel>.Success(new CreateParkingZoneResponceModel
            {
                Id = createModel.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var delete = _dataBaseContext.ParkingZones.FirstOrDefault(x => x.Id == id);
            if (delete == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "ParkingZones not found" });
            }

            _dataBaseContext.ParkingZones.Remove(delete);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<List<ParkingZoneResponceModel>>> GetAllAsync()
        {
            var getAll = await _dataBaseContext.ParkingZones
                .AsNoTracking()
                .ProjectTo<ParkingZoneResponceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ApiResult<List<ParkingZoneResponceModel>>.Success(getAll);
        }

        public async Task<ApiResult<ParkingZoneResponceModel>> GetByIdAsync(Guid id)
        {
            var getById = await _dataBaseContext.ParkingZones
                .AsNoTracking()
                .ProjectTo<ParkingZoneResponceModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (getById == null)
            {
                return ApiResult<ParkingZoneResponceModel>.Failure(
                                new List<string> { "ParkingZones not found" });
            }

            if(getById.HasActiveDiscount == true)
            {
                
            }

            return ApiResult<ParkingZoneResponceModel>.Success(getById);
        }

        public async Task<ApiResult<UpdateParkingZoneResponceModel>> UpdateAsync(Guid id, 
            UpdateParkingZoneModel update)
        {
            var updateModel = await _dataBaseContext.ParkingZones.FirstOrDefaultAsync(d => d.Id == id);
            if (updateModel == null)
            {
                return ApiResult<UpdateParkingZoneResponceModel>.Failure(new List<string> { "ParkingZone not found" });
            }

            _mapper.Map(update, updateModel);
            updateModel.UpdatedOn = DateTime.UtcNow;
            _dataBaseContext.ParkingZones.Update(updateModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<UpdateParkingZoneResponceModel>.Success(new UpdateParkingZoneResponceModel
            {
                Id = updateModel.Id
            });
        }
    }
}
