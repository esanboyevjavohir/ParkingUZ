using AutoMapper;
using ParkingUZ.Application.Models.Discount;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Repositories.Interface;

namespace ParkingUZ.Application.Services.Implement
{
    public class DiscountService : IDiscountService
    {
        private readonly IMapper _mapper;
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IMapper mapper, IDiscountRepository discountRepository)
        {
            _mapper = mapper;
            _discountRepository = discountRepository;
        }

        public async Task<CreateDiscountResponceModel> CreateAsync(CreateDiscountModel create,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Discount>(create);

            return new CreateDiscountResponceModel
            {
                Id = (await _discountRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _discountRepository.GetFirstAsync(d => d.Id == id);
            if(todoItem == null) 
                return false;

            await _discountRepository.DeleteAsync(todoItem);
            return true;
        }

        public async Task<List<DiscountResponceModel>> GetAllAsync()
        {
            var responce = await _discountRepository.GetAllAsync(d => true);
            return _mapper.Map<List<DiscountResponceModel>>(responce);
        }

        public async Task<DiscountResponceModel> GetByIdAsync(Guid id)
        {
            var todoItem = await _discountRepository.GetFirstAsync(d => d.Id == id);
            if(todoItem == null)
                throw new ArgumentNullException(nameof(todoItem));

            return _mapper.Map<DiscountResponceModel>(todoItem);
        }

        public async Task<UpdateDiscountResponceModel> UpdateAsync(Guid id, 
            UpdateDiscountModel update, CancellationToken cancellationToken = default)
        {
            var todoItem = await _discountRepository.GetFirstAsync(d => d.Id == id);

            _mapper.Map(update, todoItem);

            return new UpdateDiscountResponceModel()
            {
                Id = (await _discountRepository.UpdateAsync(todoItem)).Id
            };
        }
    }
}
