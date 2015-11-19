using NSmtp.Models.Responses;
using System.Net.Mail;

namespace NSmtp.Processors
{
    public interface IConnectionEngine
    {
        IResponse Execute(MailMessage mailMessage);
    }
}
