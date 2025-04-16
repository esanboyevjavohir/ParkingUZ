using ParkingUZ.Core.Common;
using ParkingUZ.Core.Enums;

namespace ParkingUZ.Core.Entities
{
    public sealed class User : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; } = UserRole.Candidate;
        public string Salt { get; set; }
        public string PasswordHash { get; set; } = null!;
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public string ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordTokenExpiry { get; set; }

        public DateTime? CreatedOn { get; set; }    
        public DateTime? UpdatedOn { get; set; }    

        public ICollection<OtpCode> OtpCodes { get; set; } = new List<OtpCode>();
    }
}
