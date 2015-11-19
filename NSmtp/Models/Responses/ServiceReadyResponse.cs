using NSmtp.Enums;
namespace NSmtp.Models.Responses
{
    public class ServiceReadyResponse : IResponse
    {
        public ServiceReadyResponse(string text)
        {
            ResponseText = text;
        }
        public Enums.SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.ServiceReady; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
