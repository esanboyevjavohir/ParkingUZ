using ParkingUZ.Application.Models;
using ParkingUZ.Application.Models.User;
using ParkingUZ.Core.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace ParkingUZ.Application.Helpers.GenerateJwt;

public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccesToken(CreateUserModel user);
    JwtSecurityToken GenerateAccesToken(User user);
    string GenerateRefreshToken();
}
