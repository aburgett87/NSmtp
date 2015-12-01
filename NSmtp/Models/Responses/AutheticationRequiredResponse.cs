using NSmtp.Enums;
namespace NSmtp.Models.Responses
{
    public class AutheticationRequiredResponse : IResponse
    {
        public AutheticationRequiredResponse(string text)
        {
            ResponseText = text;
        }

        public SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.AuthenticationRequired; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
