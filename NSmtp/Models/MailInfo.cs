using System.Net.Mail;

namespace NSmtp.Models
{
    public class MailInfo : IMailInfo
    {
        public IHostInfo HostInfo { get; set; }
        public MailMessage MailMessage { get; set; }
    }
}
