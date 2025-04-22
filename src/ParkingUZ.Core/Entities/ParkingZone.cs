using ParkingUZ.Core.Common;

namespace ParkingUZ.Core.Entities
{
    public class ParkingZone : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalSpots { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal XCoordinate { get; set; }
        public decimal YCoordinate { get; set; }

        public Discount Discount { get; set; }

        public bool HasActiveDiscount => Discount != null && Discount.IsActive;

        public List<Review> Reviews = new List<Review>();
        public List<ParkingSpot> ParkingSpots = new List<ParkingSpot>();

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
