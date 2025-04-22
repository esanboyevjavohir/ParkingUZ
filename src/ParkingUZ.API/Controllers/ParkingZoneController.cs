using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Application.Models.ParkingZoneModel;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = "AdminOrCandidate")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _parkingZoneService.GetByIdAsync(id);
                if(!responce.Succedded)
                    return BadRequest(responce);

                return Ok(responce);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("GetAll")]
        [Authorize(Policy = "AdminOrCandidate")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _parkingZoneService.GetAllAsync();
            if(!responce.Succedded) 
                return BadRequest(responce);

            return Ok(responce);
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> CreateAsync(CreateParkingZoneModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _parkingZoneService.CreateAsync(model);
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
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateParkingZoneModel update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _parkingZoneService.UpdateAsync(id, update);
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
                var responce = await _parkingZoneService.DeleteAsync(id);
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
