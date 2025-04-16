using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "AdminOrCandidate")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _parkingSpotService.GetByIdAsync(id);
                if (!responce.Succedded)
                    return BadRequest(responce);

                return Ok(responce);
            }
            catch(Exception ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }

        [HttpGet("GetAll")]
        [Authorize(Policy = "AdminOrCandidate")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _parkingSpotService.GetAllAsync();
            if(!res.Succedded)
                return BadRequest(res);

            return Ok(res);
        }

        [HttpPost("Create")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> CreateAsync(CreateParkingSpotModel model)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            try
            {
                var responce = await _parkingSpotService.CreateAsync(model);
                if(!responce.Succedded)
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
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateParkingSpotModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _parkingSpotService.UpdateAsync(id, model);
                if(!responce.Succedded)
                    return BadRequest(responce);

                return Ok(responce);
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
                var responce = await _parkingSpotService.DeleteAsync(id);
                if(!responce.Succedded)
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
