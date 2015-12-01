using NSmtp.Enums;
namespace NSmtp.Models.Responses
{
    public class AutheticationContinueResponse : IResponse
    {
        public AutheticationContinueResponse(string text)
        {
            ResponseText = text;
        }

        public SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.AuthenticationContinue; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
