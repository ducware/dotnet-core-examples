using DemoCache.Core.Models;
using DemoCache.Queries.Users.GetUserById;
using DemoCache.Queries.Users.GetUsers;
using DemoCache.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        private readonly IMediator _mediator;
        public UserController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        /// <summary>
        /// Get the list of user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserListAsync()
        {

            var users = await _mediator.Send(new GetUsersQuery());
            if (users == null)
            {
                return BadRequest("Danh sách trống");
            }
            return Ok(users);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
            {
                return NotFound("Không tìm thấy user");
            }
            return Ok(user);
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(User user)
        {
            var item = await _userService.CreateUser(user);

            if (item)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(User user)
        {
            if (user != null)
            {
                var item = await _userService.UpdateUser(user);
                if (item)
                {
                    return Ok(item);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int id)
        {
            var user = await _userService.DeleteUser(id);

            if (user)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
