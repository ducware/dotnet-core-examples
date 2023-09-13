using Hangfire;
using Hangfire_RabbitMQ.Models;
using Hangfire_RabbitMQ.RabbitMQ;
using Hangfire_RabbitMQ.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire_RabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IRabitMQProducer _rabitMQProducer;
        private readonly IRabbitMQConsumer _rabbitMQConsumer;

        public UserController(ILogger<UserController> logger, IUserService userService, IRabitMQProducer rabitMQProducer, IRabbitMQConsumer rabbitMQConsumer)
        {
            _logger = logger;
            _userService = userService;
            _rabitMQProducer = rabitMQProducer;
            _rabbitMQConsumer = rabbitMQConsumer;
        }

        [HttpGet("user-list")]
        public IEnumerable<User> UserList()
        {
            var users = _userService.GetUserList();
            return users;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var res = _userService.GetUserById(id);
            return Ok(res);
        }

        [HttpPost("sync-data")]
        public IActionResult AddUser()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userData = _rabbitMQConsumer.GetUserMessage<User>();

            while(userData != null) {
                BackgroundJob.Schedule(() => _userService.AddUser(userData), TimeSpan.FromSeconds(15));
                userData = _rabbitMQConsumer.GetUserMessage<User>();
            }

            if(userData == null)
            {
                return Ok("Đã thực hiện xong"); 
            }
            return Ok("Đang thực hiện...");
        }

        [HttpPost("add-user-to-queue")]
        public IActionResult AddUserToQueue(User user)
        {
             _rabitMQProducer.SendUserMessage(user);
            return Ok(user);
        }

        [HttpPut("update-user")]
        public IActionResult UpdateUser(User user)
        {
            var res = _userService.UpdateUser(user);
            return Ok(res);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var res = _userService.DeleteUser(id);
            return Ok(res);
        }
    }
}
