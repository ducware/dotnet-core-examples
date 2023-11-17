namespace MinimalAPI.CouponApi.Models
{
    public class UpdateCouponDto
    {
        public string Name { get; set; } = null!;
        public int Percent { get; set; }
        public bool IsActive { get; set; }
    }
}
