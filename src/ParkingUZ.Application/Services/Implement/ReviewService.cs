using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.Reservation;
using ParkingUZ.Application.Models.Review;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public ReviewService(IMapper mapper, DataBaseContext dataBaseContext)
        {
            _mapper = mapper;
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ApiResult<CreateReviewResponceModel>> CreateAsync(CreateReviewModel create)
        {
            var createModel = _mapper.Map<Review>(create);
            createModel.CreatedOn = DateTime.UtcNow;

            _dataBaseContext.Reviews.Add(createModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<CreateReviewResponceModel>.Success(new CreateReviewResponceModel
            {
                Id = createModel.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var delete = _dataBaseContext.Reviews.FirstOrDefault(x => x.Id == id);
            if (delete == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "ParkingZones not found" });
            }

            _dataBaseContext.Reviews.Remove(delete);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<List<ReviewResponceModel>>> GetAllAsync()
        {
            var getAll = await _dataBaseContext.Reviews
                .AsNoTracking()
                .ProjectTo<ReviewResponceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ApiResult<List<ReviewResponceModel>>.Success(getAll);
        }

        public async Task<ApiResult<ReviewResponceModel>> GetByIdAsync(Guid id)
        {
            var getById = await _dataBaseContext.Reviews
                .AsNoTracking()
                .ProjectTo<ReviewResponceModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (getById == null)
            {
                return ApiResult<ReviewResponceModel>.Failure(
                                new List<string> { "ParkingZones not found" });
            }

            return ApiResult<ReviewResponceModel>.Success(getById);
        }

        public async Task<ApiResult<UpdateReviewResponceModel>> UpdateAsync(Guid id, UpdateReviewModel update)
        {
            var updateModel = await _dataBaseContext.Reviews.FirstOrDefaultAsync(d => d.Id == id);
            if (updateModel == null)
            {
                return ApiResult<UpdateReviewResponceModel>.Failure(new List<string> { "ParkingZone not found" });
            }

            _mapper.Map(update, updateModel);
            updateModel.UpdatedOn = DateTime.UtcNow;
            _dataBaseContext.Reviews.Update(updateModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<UpdateReviewResponceModel>.Success(new UpdateReviewResponceModel
            {
                Id = updateModel.Id
            });
        }
    }
}
