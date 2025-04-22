using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.PaymentModel;
using ParkingUZ.Application.Models.QRCodeModel;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Persistence;

namespace ParkingUZ.Application.Services.Implement
{
    public class QRCodeService : IQRCodeService
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public QRCodeService(IMapper mapper, DataBaseContext dataBaseContext)
        {
            _mapper = mapper;
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ApiResult<CreateQRCodeResponceModel>> CreateAsync(CreateQRCodeModel create)
        {
            var createModel = _mapper.Map<QRCode>(create);
            createModel.CreatedOn = DateTime.UtcNow;

            _dataBaseContext.QRCodes.Add(createModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<CreateQRCodeResponceModel>.Success(new CreateQRCodeResponceModel
            {
                Id = createModel.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var delete = _dataBaseContext.QRCodes.FirstOrDefault(x => x.Id == id);
            if (delete == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "ParkingZones not found" });
            }

            _dataBaseContext.QRCodes.Remove(delete);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<List<QRCodeResponceModel>>> GetAllAsync()
        {
            var getAll = await _dataBaseContext.QRCodes
                .AsNoTracking()
                .ProjectTo<QRCodeResponceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ApiResult<List<QRCodeResponceModel>>.Success(getAll);
        }

        public async Task<ApiResult<QRCodeResponceModel>> GetByIdAsync(Guid id)
        {
            var getById = await _dataBaseContext.QRCodes
                .AsNoTracking()
                .ProjectTo<QRCodeResponceModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (getById == null)
            {
                return ApiResult<QRCodeResponceModel>.Failure(
                                new List<string> { "ParkingZones not found" });
            }

            return ApiResult<QRCodeResponceModel>.Success(getById);
        }

        public async Task<ApiResult<UpdateQRCodeResponceModel>> UpdateAsync(Guid id, UpdateQRCodeModel update)
        {
            var updateModel = await _dataBaseContext.QRCodes.FirstOrDefaultAsync(d => d.Id == id);
            if (updateModel == null)
            {
                return ApiResult<UpdateQRCodeResponceModel>.Failure(new List<string> { "ParkingZone not found" });
            }

            _mapper.Map(update, updateModel);
            updateModel.UpdatedOn = DateTime.UtcNow;
            _dataBaseContext.QRCodes.Update(updateModel);
            await _dataBaseContext.SaveChangesAsync();

            return ApiResult<UpdateQRCodeResponceModel>.Success(new UpdateQRCodeResponceModel
            {
                Id = updateModel.Id
            });
        }
    }
}
