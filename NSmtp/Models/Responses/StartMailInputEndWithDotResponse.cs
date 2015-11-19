using NSmtp.Enums;

namespace NSmtp.Models.Responses
{
    public class StartMailInputEndWithDotResponse : IResponse
    {
        public StartMailInputEndWithDotResponse(string responseText)
        {
            ResponseText = responseText;
        }

        public SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.StartMailInputEndWithDot; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
