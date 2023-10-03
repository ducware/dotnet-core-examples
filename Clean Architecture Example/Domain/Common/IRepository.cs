namespace Domain.Common
{
    public interface IRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
