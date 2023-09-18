using Microsoft.AspNetCore.Mvc;
using Send_Email.Models;
using Send_Email.Services;

namespace Send_Email.Controllers
{
    [Route("v1/send_mail")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public SendMailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailAsync(EmailDto request)
        {
            _emailService.SendEmail(request);
            return Ok("Email sent");
        }
    }
}
