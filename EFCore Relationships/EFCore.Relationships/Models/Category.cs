using System.Text.Json.Serialization;

namespace EFCore.Relationships.Models
{
    public class Category // Category (1:n) Product(CategoryId)
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}
