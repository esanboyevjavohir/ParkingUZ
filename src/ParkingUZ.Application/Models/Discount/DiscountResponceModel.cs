namespace ParkingUZ.Application.Models.Discount
{
    public class DiscountResponceModel : BaseResponceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive {  get; set; }
    }
}
