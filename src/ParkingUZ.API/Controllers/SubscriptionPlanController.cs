using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Models.QRCode;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Services.Implement;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Application.Models.SubscriptionPlan;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = "AdminOrCandidate")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _subscriptionPlanService.GetByIdAsync(id);
                if (!responce.Succedded)
                    return BadRequest(responce);

                return Ok(responce);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        [Authorize(Policy = "AdminOrCandidate")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _subscriptionPlanService.GetAllAsync();
            if (!responce.Succedded)    
                return BadRequest(responce);

            return Ok(responce);
        }

        [HttpPost("Create")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Create(CreateSubscriptionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _subscriptionPlanService.CreateAsync(model);
                if (!responce.Succedded)
                    return BadRequest(responce);

                return Ok(responce);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateSubscriptionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _subscriptionPlanService.UpdateAsync(id, model);
                if(!res.Succedded)
                    return BadRequest(res);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("Delete/{id:guid}")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var responce = await _subscriptionPlanService.DeleteAsync(id);
                if (!responce.Succedded)
                    return BadRequest(responce);

                return Ok(responce);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
