namespace SWT.Services.CouponAPI.Models.Dto
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponName { get; set; }
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }
        public string CouponCode { get; set; }
    }
}
