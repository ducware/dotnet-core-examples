namespace DemoCache.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        int Complete();
    }
}
