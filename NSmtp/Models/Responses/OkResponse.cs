using NSmtp.Enums;

namespace NSmtp.Models.Responses
{
    public class OkResponse : IResponse
    {
        public OkResponse(string responseText)
        {
            ResponseText = responseText;
        }

        public SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.OK; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
