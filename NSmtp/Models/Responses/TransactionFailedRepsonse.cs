using NSmtp.Enums;

namespace NSmtp.Models.Responses
{
    public class TransactionFailedRepsonse : IResponse
    {
        public TransactionFailedRepsonse(string text)
        {
            ResponseText = text;
        }

        public SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.TransactionFailed; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
