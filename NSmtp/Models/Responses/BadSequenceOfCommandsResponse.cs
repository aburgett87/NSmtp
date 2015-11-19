using NSmtp.Enums;

namespace NSmtp.Models.Responses
{
    public class BadSequenceOfCommandsResponse : IResponse
    {
        public BadSequenceOfCommandsResponse(string responseText)
        {
            ResponseText = responseText;
        }

        public SmtpResponseCode ResponseCode
        {
            get { return SmtpResponseCode.BadSequenceOfCommands; }
        }

        public string ResponseText
        {
            get;
            private set;
        }
    }
}
