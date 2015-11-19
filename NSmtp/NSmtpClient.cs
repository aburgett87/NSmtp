using System.Net.Mail;
using NSmtp.Models;
using NSmtp.Processors;
using NSmtp.Enums;

namespace NSmtp
{
    public class NSmtpClient : ISmtpClient
    {
        private readonly IConnectionEngine _connectionEngine;

        public NSmtpClient(IConnectionEngine connectionEngine)
        {
            _connectionEngine = connectionEngine;
        }

        public void Send(MailMessage mailMessage)
        {
            var response = _connectionEngine.Execute(mailMessage);

            if(response.ResponseCode != SmtpResponseCode.ClosingTransmissionChannel)
                throw new SmtpException("Server returned " + response.ResponseCode + " " + response.ResponseText);
        }
    }
}
