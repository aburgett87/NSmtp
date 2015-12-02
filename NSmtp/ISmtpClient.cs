using System.Net.Mail;
using System.IO;

namespace NSmtp
{
    public interface ISmtpClient
    {
        void Send(MailMessage mailMessage);
    }
}
