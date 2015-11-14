using System.Net.Mail;
using NSmtp.Models;

namespace NSmtp
{
    public class SmtpClient : ISmtpClient
    {
        private readonly IHostInfo _hostInfo;

        public SmtpClient(IHostInfo hostInfo)
        {
            _hostInfo = hostInfo;
        }

        public SmtpClient(IHostInfo hostInfo, ISmtpCommandExecutor commandExecutor)
        {

        }

        public void Send(MailMessage mailMessage)
        {
            var mailInfo = new MailInfo
            {
                HostInfo = _hostInfo,
                MailMessage = mailMessage
            };

            
        }
    }
}
