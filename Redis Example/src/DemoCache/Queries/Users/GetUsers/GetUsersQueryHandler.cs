using DemoCache.Core.Models;
using DemoCache.Domain.Queries;
using DemoCache.Services.Interfaces;

namespace DemoCache.Queries.Users.GetUsers
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly IUserService _userService;
        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsers();
            return users;
        }
    }
}
