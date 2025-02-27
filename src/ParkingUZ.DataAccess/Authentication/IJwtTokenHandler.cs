using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess;
using System.IdentityModel.Tokens.Jwt;

namespace ParkingUZ.DataAccess.Authentication
{
    public interface IJwtTokenHandler
    {
        JwtSecurityToken GenerateAccesToken(UserForCreationDTO user);
        JwtSecurityToken GenerateAccesToken(User user);
        string GenerateRefreshToken();
    }
}
