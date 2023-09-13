namespace DemoElasticsearch.Core.Models
{
    public class Product : BaseModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
    }
}
