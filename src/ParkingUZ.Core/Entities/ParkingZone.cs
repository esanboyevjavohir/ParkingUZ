using ParkingUZ.Core.Common;
using ParkingUZ.Core.Enums;

namespace ParkingUZ.Core.Entities
{
    public class ParkingZone : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalSpots { get; set; }
        public decimal PricePerHour { get; set; }

        public List<Discount> Discounts = new List<Discount>();
        public Discount ActiveDiscount => Discounts.FirstOrDefault
            (d => d.StartDate <= DateTime.UtcNow && d.EndDate >= DateTime.UtcNow);

        public List<Review> Reviews = new List<Review>();
        public List<ParkingSpot> ParkingSpots = new List<ParkingSpot>();

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
