using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Models.QRCode;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Services.Implement;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Application.Models.SubscriptionPlan;

namespace ParkingUZ.API.Controllers
{
    public class SubscriptionPlanController : ApiController
    {
        private readonly ISubscriptionPlanService _subscriptionPlanService;

        public SubscriptionPlanController(ISubscriptionPlanService subscriptionPlanService)
        {
            _subscriptionPlanService = subscriptionPlanService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _subscriptionPlanService.GetByIdAsync(id);
                return Ok(ApiResult<SubscriptionResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _subscriptionPlanService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<SubscriptionResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateSubscriptionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _subscriptionPlanService.CreateAsync(model);
                return Ok(ApiResult<CreateSubscriptionResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateSubscriptionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _subscriptionPlanService.UpdateAsync(id, model);
                return Ok(ApiResult<UpdateSubscriptionResponceModel>.Success(res));
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
                var responce = await _subscriptionPlanService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
