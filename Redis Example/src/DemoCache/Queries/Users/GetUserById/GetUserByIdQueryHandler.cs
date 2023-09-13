using DemoCache.Core.Models;
using DemoCache.Domain.Queries;
using DemoCache.Services.Interfaces;

namespace DemoCache.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
    {
        private readonly IUserService _userService;
        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserById(request.Id);
            return user;
        }
    }
}
