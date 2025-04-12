using ParkingUZ.Core.Common;

namespace ParkingUZ.Core.Entities
{
    public class Review : BaseEntity, IAuditedEntity
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ParkingZoneId { get; set; }
        public ParkingZone ParkingZone { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
