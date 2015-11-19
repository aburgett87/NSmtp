using NSmtp.Enums;

namespace NSmtp.Models.Responses
{
    public class SyntaxErrorCommandUnrecognisedResponse: IResponse
    {
        public SyntaxErrorCommandUnrecognisedResponse(string text)
        {
            ResponseText = text;
        }

        public Enums.SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.SyntaxErrorCommandUnrecognised; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
