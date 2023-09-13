using DapperExample.Repositories.Fruits;

namespace DapperExample.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IFruitRepository Fruits { get; }
        int Complete();
    }
}
