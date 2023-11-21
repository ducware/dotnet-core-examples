namespace EFCore.Relationships.Models.DTOs.Products
{
    public class CreateProductDto
    {
        public int Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
