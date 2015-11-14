using NSmtp.Models;
using System.Net.Mail;

namespace NSmtp.Converters
{
    public interface IMailMessageConverter<out T> where T : class
    {
        T Convert(MailMessage mailMessage);
    }
}
