using NSmtp.Models.Responses;

namespace NSmtp.Parsers
{
    public interface IResponseCreator
    {
        IResponse Create(string code, string text);
    }
}
