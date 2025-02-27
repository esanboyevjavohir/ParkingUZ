namespace ParkingUZ.Application.DataTransferObject.Authentication
{
    public record TokenDTO(string accessToken,
        string refreshToken, DateTime expireDate);
}
