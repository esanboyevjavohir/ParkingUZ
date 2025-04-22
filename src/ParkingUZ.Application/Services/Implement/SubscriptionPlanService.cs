using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.ReviewModel;
using ParkingUZ.Application.Models.SubscriptionPlanModel;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public SubscriptionPlanService(IMapper mapper, DataBaseContext dataBaseContext)
        {
            _mapper = mapper;
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ApiResult<CreateSubscriptionResponceModel>> CreateAsync(CreateSubscriptionModel create)
        {
            var createModel = _mapper.Map<SubscriptionPlan>(create);
            createModel.CreatedOn = DateTime.UtcNow;

            _dataBaseContext.SubscriptionPlans.Add(createModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<CreateSubscriptionResponceModel>.Success(new CreateSubscriptionResponceModel
            {
                Id = createModel.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var delete = _dataBaseContext.SubscriptionPlans.FirstOrDefault(x => x.Id == id);
            if (delete == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "ParkingZones not found" });
            }

            _dataBaseContext.SubscriptionPlans.Remove(delete);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<List<SubscriptionResponceModel>>> GetAllAsync()
        {
            var getAll = await _dataBaseContext.SubscriptionPlans
                .AsNoTracking()
                .ProjectTo<SubscriptionResponceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ApiResult<List<SubscriptionResponceModel>>.Success(getAll);
        }

        public async Task<ApiResult<SubscriptionResponceModel>> GetByIdAsync(Guid id)
        {
            var getById = await _dataBaseContext.SubscriptionPlans
                .AsNoTracking()
                .ProjectTo<SubscriptionResponceModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (getById == null)
            {
                return ApiResult<SubscriptionResponceModel>.Failure(
                                new List<string> { "ParkingZones not found" });
            }

            return ApiResult<SubscriptionResponceModel>.Success(getById);
        }

        public async Task<ApiResult<UpdateSubscriptionResponceModel>> UpdateAsync(Guid id, UpdateSubscriptionModel update)
        {
            var updateModel = await _dataBaseContext.SubscriptionPlans.FirstOrDefaultAsync(d => d.Id == id);
            if (updateModel == null)
            {
                return ApiResult<UpdateSubscriptionResponceModel>.Failure(new List<string> { "ParkingZone not found" });
            }

            _mapper.Map(update, updateModel);
            updateModel.UpdatedOn = DateTime.UtcNow;
            _dataBaseContext.SubscriptionPlans.Update(updateModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<UpdateSubscriptionResponceModel>.Success(new UpdateSubscriptionResponceModel
            {
                Id = updateModel.Id
            });
        }
    }
}
