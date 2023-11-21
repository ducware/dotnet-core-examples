using EFCore.Relationships.Data;
using EFCore.Relationships.Models;

namespace EFCore.Relationships.Repository.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public IUnitOfWork UnitOfWork { get { return _context; } }
        public CategoryRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Category> AddAsync(Category entity)
        {
            Category category = (await _context.Categories.AddAsync(entity)).Entity;
            await UnitOfWork.SaveChangesAsync();
            return category;
        }

        public Task DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
