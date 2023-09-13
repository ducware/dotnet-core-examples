using Hangfire_RabbitMQ.Data;
using Hangfire_RabbitMQ.Models;

namespace Hangfire_RabbitMQ.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            var result = _context.Users.Add(user);
            _context.SaveChanges();
            return result.Entity;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public bool DeleteUser(int id)
        {
            var filteredData = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            var result = _context.Remove(filteredData);
            _context.SaveChanges();
            return result != null ? true : false;
        }

        public User GetUserById(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUserList()
        {
            return _context.Users.ToList();
        }

        public User UpdateUser(User user)
        {
            var result = _context.Users.Update(user);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
