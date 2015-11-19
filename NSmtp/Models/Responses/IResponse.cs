using NSmtp.Enums;

namespace NSmtp.Models.Responses
{
    public interface IResponse
    {
        SmtpResponseCode ResponseCode { get; }
        string ResponseText { get; }
    }
}
