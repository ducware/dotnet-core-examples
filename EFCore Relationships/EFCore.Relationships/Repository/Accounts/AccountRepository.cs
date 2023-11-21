using EFCore.Relationships.Data;
using EFCore.Relationships.Models;

namespace EFCore.Relationships.Repository.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;
        public IUnitOfWork UnitOfWork { get { return _context; } }
        public AccountRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Account> AddAsync(Account entity)
        {
            Account category = (await _context.Accounts.AddAsync(entity)).Entity;
            await UnitOfWork.SaveChangesAsync();
            return category;
        }

        public Task DeleteAsync(Account entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> GetAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateAsync(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
