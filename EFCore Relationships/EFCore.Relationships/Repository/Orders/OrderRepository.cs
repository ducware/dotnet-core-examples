using EFCore.Relationships.Data;
using EFCore.Relationships.Models;

namespace EFCore.Relationships.Repository.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public IUnitOfWork UnitOfWork { get { return _context; } }
        public OrderRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order> AddAsync(Order entity)
        {
            Order order = (await _context.Orders.AddAsync(entity)).Entity;
            await UnitOfWork.SaveChangesAsync();
            return order;
        }

        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Order> GetByIdIncludeProductAsync(int id)
        {
            return await _context.Orders.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetIncludeProductAsync()
        {
            return await _context.Orders.Include(c => c.Products).ToListAsync();
        }
    }
}
