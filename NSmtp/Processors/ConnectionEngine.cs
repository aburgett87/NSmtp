using System.Net.Mail;
using NSmtp.Models.Responses;
using NSmtp.Enums;
using NSmtp.Phases;

namespace NSmtp.Processors
{
    public class ConnectionEngine : IConnectionEngine
    {
        private readonly IConnectionSetup _connectionSetup;
        private readonly IMailTransfer _mailTransfer;
        private readonly IConnectionTermination _connectionTermination;

        public ConnectionEngine(IConnectionSetup connectionSetup, 
            IMailTransfer mailTransfer, 
            IConnectionTermination connectionTermination)
        {
            _connectionSetup = connectionSetup;
            _mailTransfer = mailTransfer;
            _connectionTermination = connectionTermination;
        }

        public IResponse Execute(MailMessage mailMessage)
        {
            var response = _connectionSetup.Setup();
            
            if (response.ResponseCode != SmtpResponseCode.ServiceReady)
                return response;

            response = _mailTransfer.Execute(mailMessage);

            if (response.ResponseCode != SmtpResponseCode.OK)
                return response;

            response = _connectionTermination.Terminate();

            if(response.ResponseCode != SmtpResponseCode.ClosingTransmissionChannel)
                return response;

            return response;
        }
    }
}
