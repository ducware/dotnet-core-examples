using EFCore.Relationships.Models;
using EFCore.Relationships.Models.DTOs.Users;
using EFCore.Relationships.Repository.Users;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _userRepository.GetIncludeAccountAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };

            await _userRepository.AddAsync(user);
            return Ok("User was added");
        }
    }
}
