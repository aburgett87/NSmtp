using NSmtp.Enums;
namespace NSmtp.Models.Responses
{
    public class AutheticationFailureResponse : IResponse
    {
        public AutheticationFailureResponse(string text)
        {
            ResponseText = text;
        }

        public SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.AuthenticationFailure; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
