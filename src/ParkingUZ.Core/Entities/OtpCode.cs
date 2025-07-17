using ParkingUZ.Core.Common;
using ParkingUZ.Core.Enums;

namespace ParkingUZ.Core.Entities
{
    public class OtpCode : BaseEntity
    {
        public OtpCode() { }
        public string Code { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; } = DateTimeOffset.Now;
        public OtpCodeStatus Status { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
