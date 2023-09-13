namespace DemoCache.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int Status { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
