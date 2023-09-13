using DemoCache.Core.Models;
using DemoCache.Domain.Queries;

namespace DemoCache.Queries.Users.GetUsers
{
    public class GetUsersQuery : IQuery<IEnumerable<User>>
    {
    }
}
