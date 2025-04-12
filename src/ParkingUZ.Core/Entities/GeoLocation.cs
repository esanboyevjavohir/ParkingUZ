using ParkingUZ.Core.Common;

namespace ParkingUZ.Core.Entities
{
    public class GeoLocation : BaseEntity, IAuditedEntity
    {
        public decimal XCoordinate { get; set; }
        public decimal YCoordinate { get; set; }
        public ParkingZone ParkingZone { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
