using NSmtp.Enums;
namespace NSmtp.Models.Responses
{
    public class AutheticationOkResponse : IResponse
    {
        public AutheticationOkResponse(string text)
        {
            ResponseText = text;
        }

        public SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.AuthenticationOK; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
