using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Models.QRCode;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Services.Implement;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Application.Models.Reservation;
using Microsoft.AspNetCore.Authorization;

namespace ParkingUZ.API.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("GetById/{id}")]
        [Authorize(Policy = "AdminOrCandidate")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _reservationService.GetByIdAsync(id);
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
            var responce = await _reservationService.GetAllAsync();
            if (!responce.Succedded)
                return BadRequest(responce);

            return Ok(responce);
        }

        [HttpPost("Create")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Create(CreateReservationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _reservationService.CreateAsync(model);
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
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateReservationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _reservationService.UpdateAsync(id, model);
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
                var responce = await _reservationService.DeleteAsync(id);
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
