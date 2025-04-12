using ParkingUZ.Core.Enums;

namespace ParkingUZ.Core.UserResponse
{
    public class UserResponseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
    }
}
