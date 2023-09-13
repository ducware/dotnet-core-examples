using Hangfire_RabbitMQ.Models;

namespace Hangfire_RabbitMQ.Services
{
    public interface IUserService
    {
        public IEnumerable<User> GetUserList();
        public User GetUserById(int id);
        public User AddUser(User user);
        public User UpdateUser(User user);
        public bool DeleteUser(int id);
        public void Complete();
    }
}
