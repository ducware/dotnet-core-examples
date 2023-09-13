using DemoCache.Core.Models;

namespace DemoCache.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(User driver);

        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<bool> UpdateUser(User driver);

        Task<bool> DeleteUser(int id);
    }
}
