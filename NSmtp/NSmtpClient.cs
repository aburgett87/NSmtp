using System.Net.Mail;
using NSmtp.Models;
using NSmtp.Processors;
using NSmtp.Enums;
using NSmtp.Utilities;
using System.IO;

namespace NSmtp
{
    public class NSmtpClient : ISmtpClient
    {
        private readonly IConnectionEngine _connectionEngine;
        private readonly IStreamManager _streamManager;
        private readonly IStreamFactory _streamFactory;

        public NSmtpClient(IConnectionEngine connectionEngine,
            IStreamManager streamManager,
            IStreamFactory streamFactory)
        {
            _connectionEngine = connectionEngine;
            _streamManager = streamManager;
            _streamFactory = streamFactory;
        }

        public void Send(MailMessage mailMessage)
        {
            _streamManager.Add(_streamFactory.Create());
            var response = _connectionEngine.Execute(mailMessage);

            if(response.ResponseCode != SmtpResponseCode.ClosingTransmissionChannel)
                throw new SmtpException("Server returned " + response.ResponseCode + " " + response.ResponseText);
            _streamManager.Close();
        }
    }
}
