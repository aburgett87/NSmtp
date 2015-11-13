using System.Net.Mail;

namespace NSmtp
{
    public interface ISmtpClient
    {
        void Send(MailMessage mailMessage);
    }
}
