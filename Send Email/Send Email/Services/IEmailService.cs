using Send_Email.Models;

namespace Send_Email.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
