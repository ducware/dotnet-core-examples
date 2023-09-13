using DemoCache.Core.Interfaces;
using DemoCache.Infrastructure.Data;

namespace DemoCache.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _context;
        public IUserRepository User { get; private set; }

        public UnitOfWork(ApiDbContext context, IUserRepository user)
        {
            _context = context;
            User = user;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
