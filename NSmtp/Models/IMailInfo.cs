using System.Net.Mail;
using NSmtp.Enums;


namespace NSmtp.Models
{
    public interface IMailInfo
    {
        IHostInfo HostInfo { get; set; }
        MailMessage MailMessage { get; set; }
    }
}
