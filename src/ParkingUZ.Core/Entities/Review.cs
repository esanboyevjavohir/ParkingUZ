using ParkingUZ.Core.Common;

namespace ParkingUZ.Core.Entities
{
    public class Review : BaseEntity, IAuditedEntity
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ParkingLotId { get; set; }
        public ParkingLot ParkingLot { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
