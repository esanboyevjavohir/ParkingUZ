using AutoMapper;
using ParkingUZ.Application.Models.QRCode;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.Application.Services.Implement
{
    public class QRCodeService : IQRCodeService
    {
        private readonly IMapper _mapper;
        private readonly IQRCodeRepository _qrCodeRepository;

        public QRCodeService(IMapper mapper, IQRCodeRepository qrCodeRepository)
        {
            _mapper = mapper;
            _qrCodeRepository = qrCodeRepository;
        }

        public async Task<CreateQRCodeResponceModel> CreateAsync(CreateQRCodeModel create, 
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<QRCode>(create);

            return new CreateQRCodeResponceModel
            {
                Id = (await _qrCodeRepository.AddAsync(todoItem)).Id,
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var res = await _qrCodeRepository.GetFirstAsync(q => q.Id == id);
            if (res == null) return false;

            await _qrCodeRepository.DeleteAsync(res);
            return true;
        }

        public async Task<List<QRCodeResponceModel>> GetAllAsync()
        {
            var item = await _qrCodeRepository.GetAllAsync(q => true);
            return _mapper.Map<List<QRCodeResponceModel>>(item);
        }

        public async Task<QRCodeResponceModel> GetByIdAsync(Guid id)
        {
            var item = await _qrCodeRepository.GetFirstAsync(q => q.Id == id);
            if (item == null)
                throw new Exception("QRCode not found");

            return _mapper.Map<QRCodeResponceModel>(item);
        }

        public async Task<UpdateQRCodeResponceModel> UpdateAsync(Guid id, 
            UpdateQRCodeModel update, CancellationToken cancellationToken = default)
        {
            var res = await _qrCodeRepository.GetFirstAsync(q => q.Id==id);

            _mapper.Map(update, res);

            return new UpdateQRCodeResponceModel
            {
                Id = (await _qrCodeRepository.UpdateAsync(res)).Id
            };
        }
    }
}
