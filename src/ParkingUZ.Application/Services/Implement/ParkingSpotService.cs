using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.DiscountModel;
using ParkingUZ.Application.Models.ParkingSpotModel;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class ParkingSpotService : IParkingSpotService
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public ParkingSpotService(IMapper mapper, DataBaseContext dataBaseContext)
        {
            _mapper = mapper;
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ApiResult<CreateParkingSpotResponceModel>> CreateAsync(CreateParkingSpotModel create)
        {
            var topicEntity = _mapper.Map<ParkingSpot>(create);
            topicEntity.CreatedOn = DateTime.UtcNow;

            _dataBaseContext.ParkingSpots.Add(topicEntity);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<CreateParkingSpotResponceModel>.Success(new CreateParkingSpotResponceModel
            {
                Id = topicEntity.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var parkingSpot = _dataBaseContext.ParkingSpots.FirstOrDefault(x => x.Id == id);
            if (parkingSpot == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "ParkingSpot not found" });
            }

            _dataBaseContext.ParkingSpots.Remove(parkingSpot);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<List<ParkingSpotResponceModel>>> GetAllAsync()
        {
            var parkingSpot = await _dataBaseContext.ParkingSpots
                .AsNoTracking()
                .ProjectTo<ParkingSpotResponceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ApiResult<List<ParkingSpotResponceModel>>.Success(parkingSpot);
        }

        public async Task<ApiResult<ParkingSpotResponceModel>> GetByIdAsync(Guid id)
        {
            var parkingSpot = await _dataBaseContext.ParkingSpots
                .AsNoTracking()
                .ProjectTo<ParkingSpotResponceModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (parkingSpot == null)
            {
                return ApiResult<ParkingSpotResponceModel>.Failure(new List<string> { "ParkingSpot not found" });
            }

            return ApiResult<ParkingSpotResponceModel>.Success(parkingSpot);
        }

        public async Task<ApiResult<UpdateParkingSpotResponceModel>> UpdateAsync(Guid id, UpdateParkingSpotModel update)
        {
            var parkingSpot = await _dataBaseContext.ParkingSpots.FirstOrDefaultAsync(d => d.Id == id);
            if (parkingSpot == null)
            {
                return ApiResult<UpdateParkingSpotResponceModel>.Failure(new List<string> { "ParkingSpot not found" });
            }

            _mapper.Map(update, parkingSpot);
            parkingSpot.UpdatedOn = DateTime.UtcNow;
            _dataBaseContext.ParkingSpots.Update(parkingSpot);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<UpdateParkingSpotResponceModel>.Success(new UpdateParkingSpotResponceModel
            {
                Id = parkingSpot.Id
            });
        }
    }
}
