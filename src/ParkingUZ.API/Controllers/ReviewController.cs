using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Models.QRCode;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Services.Implement;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Application.Models.Review;

namespace ParkingUZ.API.Controllers
{
    public class ReviewController : ApiController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _reviewService.GetByIdAsync(id);
                return Ok(ApiResult<ReviewResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _reviewService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<ReviewResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateReviewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _reviewService.CreateAsync(model);
                return Ok(ApiResult<CreateReviewResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateReviewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _reviewService.UpdateAsync(id, model);
                return Ok(ApiResult<UpdateReviewResponceModel>.Success(res));
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
                var responce = await _reviewService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(responce));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
