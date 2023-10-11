using JWT_Authentication_and_Authorization_Role_Based.Models;
using JWT_Authentication_and_Authorization_Role_Based.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Authentication_and_Authorization_Role_Based.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto request)
        {
            var user = _authServices.Register(request);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto request)
        {
            var user = _authServices.Login(request);
            return Ok(user);
        }

    }
}
