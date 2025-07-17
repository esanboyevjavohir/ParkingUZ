using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Helpers.GenerateJwt;
using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.User;
using ParkingUZ.Application.Services.Interface;

namespace ParkingUZ.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Registration")]
        public async Task<ActionResult<CreateUserResponseModel>> UserSignUpAsync([FromForm] CreateUserModel createUserModel)
        {
            var create = await _userService.SignUpAsync(createUserModel);
            if (!create.Succedded)
                return BadRequest(create);

            return Created("", create);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> UserLoginAsync(LoginUserModel loginUserModel)
        {
            var result = await _userService.LoginAsync(loginUserModel);

            if(!result.Succedded)
            {
                if (result.Errors.Contains("User not found"))
                    return NotFound(result);
                if (result.Errors.Contains("Invalid password"))
                    return Unauthorized(result);

                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("ValidateAndRefreshToken")]
        public async Task<IActionResult> RefreshTokenAsync(Guid id, string refreshToken)
        {
            var result = await _userService.ValidateAndRefreshToken(id, refreshToken);
            return Ok(result);
        }

        [HttpPost("SendOtpCode")]
        public async Task<IActionResult> SendOtpCodeAsync(Guid userId)
        {
            var result = await _userService.SendOtpCode(userId);

            if (!result.Succedded)
            {
                if (result.Errors.Contains("User not found"))
                    return NotFound(result); 

                if (result.Errors.Contains("Failed to send OTP email"))
                    return StatusCode(500, result); 

                return BadRequest(result); 
            }

            return Ok(result);
        }

        [HttpPost("ResendOtpCode")]
        public async Task<ApiResult<bool>> ResendOtpCodeAsync(Guid userId)
        {
            var result = await _userService.ResendOtpCode(userId);
            return result;
        }

        [HttpPost("VerifyOtpAsync")]
        public async Task<ApiResult<bool>> VerifyOtpCodeAsync(string otpCode, Guid userId)
        {
            var result = await _userService.VerifyOtpCode(otpCode, userId);
            return result;
        }

        [HttpPost("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel email)
        {
            var result = await _userService.ForgotPasswordAsync(email.Email);
            if(!result.Succedded)
                return BadRequest(result);

            return Ok(result);  
        }

        [HttpPost("Reset-Password")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordModel model)
        {
            var result = await _userService.ResetPasswordAsync(model);
            if (!result.Succedded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState); 
            
            try
            {
                var res = await _userService.GetByIdAsync(id);
                return res == null? NotFound() : Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUsers()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var responce = await _userService.GetAllAsync();
                return responce == null? NotFound() : Ok(responce);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _userService.DeleteUserAsync(id);
                return res == null ? NotFound() : Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
