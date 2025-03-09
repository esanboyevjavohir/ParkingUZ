using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.ParkingSubscription;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.API.Controllers
{
    public class ParkingSubscriptionService : ApiController
    {
        private readonly IParkingSubscriptionService _parkingSubscriptionService;

        public ParkingSubscriptionService(IParkingSubscriptionService parkingSubscriptionService)
        {
            _parkingSubscriptionService = parkingSubscriptionService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _parkingSubscriptionService.GetByIdAsync(id);
                return Ok(ApiResult<ParkingSubscriptionResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _parkingSubscriptionService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<ParkingSubscriptionResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateParkSubsModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _parkingSubscriptionService.CreateAsync(model);
                return Ok(ApiResult<CreateParkSubsResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateParkSubsModel update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _parkingSubscriptionService.UpdateAsync(id, update);
                return Ok(ApiResult<UpdateParkSubsResponceModel>.Success(res));
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
                var responce = await _parkingSubscriptionService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
