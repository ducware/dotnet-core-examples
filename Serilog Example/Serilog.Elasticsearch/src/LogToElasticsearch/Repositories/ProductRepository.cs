using LogToElasticsearch.Data;
using LogToElasticsearch.Entities;
using LogToElasticsearch.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogToElasticsearch.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public IUnitOfWork UnitOfWork
        { get { return _context; } }

        public ProductRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> AddAsync(Product entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(Product entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async  Task UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            await Task.CompletedTask;
        }
    }
}
