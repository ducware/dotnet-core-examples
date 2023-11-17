using MinimalAPI.CouponApi.Models;

namespace MinimalAPI.CouponApi.Data
{
    public static class CouponSeed
    {
        public static List<Coupon> coupons = new()
        {
            new Coupon { Id = 1, Name = "#1", Percent = 10, IsActive = true, Created = DateTime.Now },
            new Coupon { Id = 2, Name = "#2", Percent = 20, IsActive = false, Created = DateTime.Now },
            new Coupon { Id = 3, Name = "#3", Percent = 30, IsActive = false, Created = DateTime.Now }
        };
    }
}
