using EFCore.Relationships.Models;

namespace EFCore.Relationships.Repository.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetIncludeOrderAsync();
    }
}
