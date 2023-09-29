namespace Multiple_EF_Core_DbContexts.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public List<LineItem> LineItems { get; set; } = new();
    }
}
