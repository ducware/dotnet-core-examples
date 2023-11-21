namespace EFCore.Relationships.Models.DTOs.Orders
{
    public class CreateOrderProductDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
