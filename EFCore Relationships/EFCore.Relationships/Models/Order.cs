namespace EFCore.Relationships.Models
{
    public class Order // Order([{Product}] (n:n) Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Product> Products { get; set; }
    }
}
