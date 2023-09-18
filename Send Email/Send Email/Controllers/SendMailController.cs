

using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace Send_Email.Controllers
{
    [Route("v1/send_mail")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendEmailAsyn(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("clair.rohan@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("clair.rohan@ethereal.email"));
            email.Subject = "Test email subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var stmp = new SmtpClient();
            stmp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            stmp.Authenticate("clair.rohan@ethereal.email", "SpmnuzXbUwpqDM8UuB");
            stmp.Send(email);
            stmp.Disconnect(true);

            return Ok();
        }
    }
}
