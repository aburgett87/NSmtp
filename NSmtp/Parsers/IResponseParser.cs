using NSmtp.Models;

namespace NSmtp.Parsers
{
    public interface IResponseParser
    {
        IResponse Parse(string response);
    }
}
