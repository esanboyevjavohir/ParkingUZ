using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.QRCode;
using ParkingUZ.Application.Services.Interface;

namespace ParkingUZ.API.Controllers
{
    public class QRCodeController : ApiController
    {
        private readonly IQRCodeService _qrCodeService;

        public QRCodeController(IQRCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _qrCodeService.GetByIdAsync(id);
                return Ok(ApiResult<QRCodeResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _qrCodeService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<QRCodeResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateQRCodeModel model)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            try
            {
                var responce = await _qrCodeService.CreateAsync(model);
                return Ok(ApiResult<CreateQRCodeResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateQRCodeModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _qrCodeService.UpdateAsync(id, model);
                return Ok(ApiResult<UpdateQRCodeResponceModel>.Success(res));
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
                var responce = await _qrCodeService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
