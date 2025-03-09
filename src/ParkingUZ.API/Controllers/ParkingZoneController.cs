using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Models.ParkingSubscription;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Services.Implement;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Application.Models.ParkingZone;

namespace ParkingUZ.API.Controllers
{
    public class ParkingZoneController : ApiController
    {
        private readonly IParkingZoneService _parkingZoneService;

        public ParkingZoneController(IParkingZoneService parkingZoneService)
        {
            _parkingZoneService = parkingZoneService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _parkingZoneService.GetByIdAsync(id);
                return Ok(ApiResult<ParkingZoneResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _parkingZoneService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<ParkingZoneResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateParkingZoneModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _parkingZoneService.CreateAsync(model);
                return Ok(ApiResult<CreateParkingZoneResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateParkingZoneModel update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _parkingZoneService.UpdateAsync(id, update);
                return Ok(ApiResult<UpdateParkingZoneResponceModel>.Success(res));
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
                var responce = await _parkingZoneService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
