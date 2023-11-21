using EFCore.Relationships.Models;

namespace EFCore.Relationships.Repository.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByIdIncludeProductAsync(int id);
        Task<IEnumerable<Order>> GetIncludeProductAsync();
    }
}
