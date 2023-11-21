using EFCore.Relationships.Data;
using EFCore.Relationships.Models;

namespace EFCore.Relationships.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public IUnitOfWork UnitOfWork { get { return _context; } }
        public ProductRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> AddAsync(Product entity)
        {
            Product product = (await _context.Products.AddAsync(entity)).Entity;
            await UnitOfWork.SaveChangesAsync();
            return product;
        }

        public Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetIncludeOrderAsync()
        {
            return await _context.Products.Include(c => c.Orders).ToListAsync();
        }
    }
}
