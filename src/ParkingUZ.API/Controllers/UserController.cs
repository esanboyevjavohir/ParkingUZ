using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Helpers.GenerateJwt;
using ParkingUZ.Application.Models.User;
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.DataAccess;
using System.IdentityModel.Tokens.Jwt;

namespace ParkingUZ.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenHandler _jwtTokenHandler;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IUserService userService,
            IJwtTokenHandler jwtTokenHandler, 
            IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _jwtTokenHandler = jwtTokenHandler;
            _webHostEnvironment = webHostEnvironment;
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

        [HttpPost("Create-User")]
        public async Task<IActionResult> AddUser(CreateUserModel userForCreationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createUser = await _userService.SignUpAsync(userForCreationDTO);
                var accesToken = _jwtTokenHandler.GenerateAccesToken(createUser);
                var refreshToken = _jwtTokenHandler.GenerateRefreshToken();

                return Ok(new
                {
                    AccesToken = new JwtSecurityTokenHandler().WriteToken(accesToken),
                    RefreshToken = refreshToken,
                    User = createUser
                });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /*[HttpPut("Update-User/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id,
            [FromBody] UpdateUserDTO userDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _userService.UpdateUserAsync(id, userDto);
                return res == null? NotFound() : Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }*/

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
