using System.Text.Json.Serialization;

namespace MinimalAPI.CouponApi.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Percent {  get; set; }
        public bool IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastUpdated { get; set; }

        public void Update(string name, int percent, bool isActive)
        {
            Name = name;
            Percent = percent;
            IsActive = isActive;
            LastUpdated = DateTime.Now;
        }
    }
}
