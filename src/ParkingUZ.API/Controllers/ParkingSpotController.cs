using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.ParkingSpot;
using ParkingUZ.Application.Services.Interface;

namespace ParkingUZ.API.Controllers
{
    public class ParkingSpotController : ApiController
    { 
        private readonly IParkingSpotService _parkingSpotService;

        public ParkingSpotController(IParkingSpotService parkingSpotService)
        {
            _parkingSpotService = parkingSpotService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _parkingSpotService.GetByIdAsync(id);
                return Ok(ApiResult<ParkingSpotResponceModel>.Success(responce));
            }
            catch(Exception ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _parkingSpotService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<ParkingSpotResponceModel>>.Success(res));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateParkingSpotModel model)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            try
            {
                var responce = await _parkingSpotService.CreateAsync(model);
                return Ok(ApiResult<CreateParkingSpotResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateParkingSpotModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _parkingSpotService.UpdateAsync(id, model);
                return Ok(ApiResult<UpdateParkingSpotResponceModel>.Success(responce));
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
                var responce = await _parkingSpotService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
