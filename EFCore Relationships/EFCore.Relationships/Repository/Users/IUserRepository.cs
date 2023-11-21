using EFCore.Relationships.Models;

namespace EFCore.Relationships.Repository.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetIncludeAccountAsync();
    }
}
