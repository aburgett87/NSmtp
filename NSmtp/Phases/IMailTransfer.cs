using System.Net.Mail;
using NSmtp.Models.Responses;

namespace NSmtp.Phases
{
    public interface IMailTransfer
    {
        IResponse Execute(MailMessage mailMessage);
    }
}
