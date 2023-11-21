using EFCore.Relationships.Data;
using EFCore.Relationships.Models;

namespace EFCore.Relationships.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public IUnitOfWork UnitOfWork { get { return _context; } }
        public UserRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> AddAsync(User entity)
        {
            User user = (await _context.Users.AddAsync(entity)).Entity;
            await UnitOfWork.SaveChangesAsync();
            return user;
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetIncludeAccountAsync()
        {
            return await _context.Users.Include(c => c.Account).ToListAsync();
        }
    }
}
