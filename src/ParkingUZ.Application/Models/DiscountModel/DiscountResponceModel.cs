namespace ParkingUZ.Application.Models.DiscountModel
{
    public class DiscountResponceModel : BaseResponseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive {  get; set; }
        public Guid ParkingZoneId { get; set; }
    }
}
