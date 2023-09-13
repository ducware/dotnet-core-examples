using DemoCache.Core.Models;
using DemoCache.Domain.Queries;

namespace DemoCache.Queries.Users.GetUserById
{
    public class GetUserByIdQuery : IQuery<User>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
