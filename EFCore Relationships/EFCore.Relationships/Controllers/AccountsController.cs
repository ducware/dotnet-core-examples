using EFCore.Relationships.Models;
using EFCore.Relationships.Models.DTOs.Accounts;
using EFCore.Relationships.Models.DTOs.Products;
using EFCore.Relationships.Repository.Accounts;
using EFCore.Relationships.Repository.Users;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        public AccountsController(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var accounts = await _accountRepository.GetAsync();
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAccountDto dto)
        {
            if (await _userRepository.GetByIdAsync(dto.UserId) == null)
            {
                return NotFound("user_not_exists");
            }

            var account = new Account
            {
                UserName = dto.UserName,
                Password = dto.Password,
                UserId = dto.UserId
            };

            await _accountRepository.AddAsync(account);
            return Ok("Account was added");
        }
    }
}
