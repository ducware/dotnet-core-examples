namespace Multiple_EF_Core_DbContexts.Contracts
{
    public class SubmitOrderRequest
    {
        public List<Guid> ProductIds { get; set; } = new();
    }
}
