using System.Net.Mail;

namespace NSmtp
{
    public interface IMailMessageConverter<out T>
    {
        T Convert(MailMessage message);
    }
}
