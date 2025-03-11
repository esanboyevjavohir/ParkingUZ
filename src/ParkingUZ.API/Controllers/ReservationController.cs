using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Models.QRCode;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Services.Implement;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Application.Models.Reservation;

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
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _reservationService.GetByIdAsync(id);
                return Ok(ApiResult<ReservationResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _reservationService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<ReservationResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateReservationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _reservationService.CreateAsync(model);
                return Ok(ApiResult<CreateReservationResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateReservationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _reservationService.UpdateAsync(id, model);
                return Ok(ApiResult<UpdateReservationResponceModel>.Success(res));
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
                var responce = await _reservationService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
