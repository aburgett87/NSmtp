using NSmtp.Models.Responses;

namespace NSmtp.Parsers
{
    public interface IResponseParser
    {
        IResponse Parse(string response);
    }
}
