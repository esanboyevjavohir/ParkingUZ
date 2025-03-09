using ParkingUZ.Core.Common;

namespace ParkingUZ.Application.DTO
{
    public class UserResponceDTO : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
