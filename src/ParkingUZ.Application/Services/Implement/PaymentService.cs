using AutoMapper;
using ParkingUZ.Application.Models.Payment;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.Application.Services.Implement
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<CreatePaymentResponceModel> CreateAsync(CreatePaymentModel create,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Payment>(create);

            return new CreatePaymentResponceModel
            {
                Id = (await _paymentRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _paymentRepository.GetFirstAsync(p => p.Id == id);
            if (todoItem == null) return false;

            await _paymentRepository.DeleteAsync(todoItem);
            return true;
        }

        public async Task<List<PaymentResponceModel>> GetAllAsync()
        {
            var res = await _paymentRepository.GetAllAsync(p => true);
            return _mapper.Map<List<PaymentResponceModel>>(res);
        }

        public async Task<PaymentResponceModel> GetByIdAsync(Guid id)
        {
            var todoItem = await _paymentRepository.GetFirstAsync(p => p.Id==id);
            if (todoItem == null)
                throw new Exception("Payment not found");

            return _mapper.Map<PaymentResponceModel>(todoItem);
        }

        public async Task<UpdatePaymentResponceModel> UpdateAsync(Guid id,
            UpdatePaymentModel update, CancellationToken cancellationToken = default)
        {
            var item = await _paymentRepository.GetFirstAsync(p=> p.Id == id);

            _mapper.Map(update, item);

            return new UpdatePaymentResponceModel
            {
                Id = (await _paymentRepository.UpdateAsync(item)).Id
            };
        }
    }
}
