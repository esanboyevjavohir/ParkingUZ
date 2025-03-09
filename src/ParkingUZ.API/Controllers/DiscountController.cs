
using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.Discount;
using ParkingUZ.Application.Services.Interface;

namespace ParkingUZ.API.Controllers
{
    public class DiscountController : ApiController
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _discountService.GetByIdAsync(id);
                return Ok(ApiResult<DiscountResponceModel>.Success(responce));
            }
            catch(Exception ex)
            {
                return NotFound(new {message = ex.Message});    
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResult<List<DiscountResponceModel>>>> GetAll()
        {
            var responce = await _discountService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<DiscountResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateDiscountModel model)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            try
            {
                var responce = await _discountService.CreateAsync(model);
                return Ok(ApiResult<CreateDiscountResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateDiscountModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _discountService.UpdateAsync(id, model);
                return Ok(ApiResult<UpdateDiscountResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("Delete/{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _discountService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(result));
            }
            catch(Exception ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }
    }
}
