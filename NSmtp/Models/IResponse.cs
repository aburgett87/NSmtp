using NSmtp.Enums;

namespace NSmtp.Models
{
    public interface IResponse
    {
        SmtpResponseCode ResponseCode { get; }
        string ResponseText { get; }
    }
}
