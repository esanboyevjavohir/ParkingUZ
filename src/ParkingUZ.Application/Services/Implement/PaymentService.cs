using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.ParkingZoneModel;
using ParkingUZ.Application.Models.PaymentModel;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public PaymentService(IMapper mapper, DataBaseContext dataBaseContext)
        {
            _mapper = mapper;
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ApiResult<CreatePaymentResponceModel>> CreateAsync(CreatePaymentModel create)
        {
            var createModel = _mapper.Map<Payment>(create);
            createModel.CreatedOn = DateTime.UtcNow;

            _dataBaseContext.Payments.Add(createModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<CreatePaymentResponceModel>.Success(new CreatePaymentResponceModel
            {
                Id = createModel.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var delete = _dataBaseContext.Payments.FirstOrDefault(x => x.Id == id);
            if (delete == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "ParkingZones not found" });
            }

            _dataBaseContext.Payments.Remove(delete);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<List<PaymentResponceModel>>> GetAllAsync()
        {
            var getAll = await _dataBaseContext.Payments
                .AsNoTracking()
                .ProjectTo<PaymentResponceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ApiResult<List<PaymentResponceModel>>.Success(getAll);
        }

        public async Task<ApiResult<PaymentResponceModel>> GetByIdAsync(Guid id)
        {
            var getById = await _dataBaseContext.Payments
                .AsNoTracking()
                .ProjectTo<PaymentResponceModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (getById == null)
            {
                return ApiResult<PaymentResponceModel>.Failure(
                                new List<string> { "ParkingZones not found" });
            }

            return ApiResult<PaymentResponceModel>.Success(getById);
        }

        public async Task<ApiResult<UpdatePaymentResponceModel>> UpdateAsync(Guid id, UpdatePaymentModel update)
        {
            var updateModel = await _dataBaseContext.Payments.FirstOrDefaultAsync(d => d.Id == id);
            if (updateModel == null)
            {
                return ApiResult<UpdatePaymentResponceModel>.Failure(new List<string> { "ParkingZone not found" });
            }

            _mapper.Map(update, updateModel);
            updateModel.UpdatedOn = DateTime.UtcNow;
            _dataBaseContext.Payments.Update(updateModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<UpdatePaymentResponceModel>.Success(new UpdatePaymentResponceModel
            {
                Id = updateModel.Id
            });
        }
    }
}
