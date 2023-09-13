using DapperExample.Data;
using DapperExample.Repositories.Fruits;

namespace DapperExample.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IFruitRepository Fruits { get; }

        public UnitOfWork(AppDbContext context, IFruitRepository fruitRepository)
        {
            _context = context;
            Fruits = fruitRepository;
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
