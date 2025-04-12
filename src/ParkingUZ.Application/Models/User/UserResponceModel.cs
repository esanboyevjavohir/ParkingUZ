using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.User
{
    public class UserResponceModel : BaseResponseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
    }
}
