using System.Text.Json.Serialization;

namespace EFCore.Relationships.Models
{
    public class Product // Category (1:n) Product(CategoryId)
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public Category Category { get; set; }
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}
