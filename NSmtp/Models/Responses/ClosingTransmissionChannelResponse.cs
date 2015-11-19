using NSmtp.Enums;

namespace NSmtp.Models.Responses
{
    public class ClosingTransmissionChannelResponse : IResponse
    {
        public ClosingTransmissionChannelResponse(string text)
        {
            ResponseText = text;
        }

        public SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.ClosingTransmissionChannel; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
