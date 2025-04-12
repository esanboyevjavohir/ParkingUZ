using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.ParkingSpot;
using ParkingUZ.Application.Models.ParkingSubscription;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class ParkingSubscriptionService : IParkingSubscriptionService
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public ParkingSubscriptionService(IMapper mapper, DataBaseContext dataBaseContext)
        {
            _mapper = mapper;
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ApiResult<CreateParkSubsResponceModel>> CreateAsync(CreateParkSubsModel create)
        {
            var createModel = _mapper.Map<ParkingSubscription>(create);
            createModel.CreatedOn = DateTime.UtcNow;

            _dataBaseContext.ParkingSubscriptions.Add(createModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<CreateParkSubsResponceModel>.Success(new CreateParkSubsResponceModel
            {
                Id = createModel.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var delete = _dataBaseContext.ParkingSubscriptions.FirstOrDefault(x => x.Id == id);
            if (delete == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "ParkingSubscription not found" });
            }

            _dataBaseContext.ParkingSubscriptions.Remove(delete);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<List<ParkingSubscriptionResponceModel>>> GetAllAsync()
        {
            var getAll = await _dataBaseContext.ParkingSubscriptions
                .AsNoTracking()
                .ProjectTo<ParkingSubscriptionResponceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ApiResult<List<ParkingSubscriptionResponceModel>>.Success(getAll);
        }

        public async Task<ApiResult<ParkingSubscriptionResponceModel>> GetByIdAsync(Guid id)
        {
                var getById = await _dataBaseContext.ParkingSubscriptions
                    .AsNoTracking()
                    .ProjectTo<ParkingSubscriptionResponceModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (getById == null)
                {
                    return ApiResult<ParkingSubscriptionResponceModel>.Failure(
                                    new List<string> { "ParkingSubscription not found" });
                }

                return ApiResult<ParkingSubscriptionResponceModel>.Success(getById);
        }

        public async Task<ApiResult<UpdateParkSubsResponceModel>> UpdateAsync(Guid id, UpdateParkSubsModel update)
        {
            var updateModel = await _dataBaseContext.ParkingSubscriptions.FirstOrDefaultAsync(d => d.Id == id);
            if (updateModel == null)
            {
                return ApiResult<UpdateParkSubsResponceModel>.Failure(new List<string> { "ParkingSpot not found" });
            }

            _mapper.Map(update, updateModel);
            updateModel.UpdatedOn = DateTime.UtcNow;
            _dataBaseContext.ParkingSubscriptions.Update(updateModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<UpdateParkSubsResponceModel>.Success(new UpdateParkSubsResponceModel
            {
                Id = updateModel.Id
            });
        }
    }
}
