using DemoCache.Core.Interfaces;
using DemoCache.Core.Models;
using DemoCache.Infrastructure.Data;

namespace DemoCache.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
