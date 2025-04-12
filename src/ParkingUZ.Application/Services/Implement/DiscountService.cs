using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.Discount;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class DiscountService : IDiscountService
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public DiscountService(IMapper mapper, DataBaseContext dataBaseContext)
        {
            _mapper = mapper;
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ApiResult<CreateDiscountResponceModel>> CreateAsync(CreateDiscountModel create)
        {
            var discountEntity = _mapper.Map<Discount>(create);
            discountEntity.CreatedOn = DateTime.UtcNow;

            _dataBaseContext.Discounts.Add(discountEntity);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<CreateDiscountResponceModel>.Success(new CreateDiscountResponceModel
            {
                Id = discountEntity.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var discount = _dataBaseContext.Discounts.FirstOrDefault(x=> x.Id == id);
            if (discount == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "Discount not found" });
            }

            _dataBaseContext.Discounts.Remove(discount);
            await _dataBaseContext.SaveChangesAsync();
            
            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<List<DiscountResponceModel>>> GetAllAsync()
        {
            var discouts = await _dataBaseContext.Discounts
                .AsNoTracking()
                .ProjectTo<DiscountResponceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ApiResult<List<DiscountResponceModel>>.Success(discouts);
        }

        public async Task<ApiResult<DiscountResponceModel>> GetByIdAsync(Guid id)
        {
            var discount = await _dataBaseContext.Discounts
                .AsNoTracking()
                .ProjectTo<DiscountResponceModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (discount == null)
            {
                return ApiResult<DiscountResponceModel>.Failure(new List<string> { "Discount not found" });
            }

            return ApiResult<DiscountResponceModel>.Success(discount);
        }

        public async Task<ApiResult<UpdateDiscountResponceModel>> UpdateAsync(Guid id, UpdateDiscountModel update)
        {
            var discount = await _dataBaseContext.Discounts.FirstOrDefaultAsync(d => d.Id == id);
            if (discount == null)
            {
                return ApiResult<UpdateDiscountResponceModel>.Failure(new List<string> { "Discount not found" });
            }

            _mapper.Map(update, discount);
            discount.UpdatedOn = DateTime.UtcNow;
            _dataBaseContext.Discounts.Update(discount);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<UpdateDiscountResponceModel>.Success(new UpdateDiscountResponceModel
            {
                Id = discount.Id
            });
        }
    }
}
