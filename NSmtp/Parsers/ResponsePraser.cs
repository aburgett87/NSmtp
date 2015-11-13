using NSmtp.Models;

namespace NSmtp.Parsers
{
    public class ResponsePraser : IResponseParser
    {
        private readonly IResponseCreator _responseCreator;

        public ResponsePraser(IResponseCreator responseCreator)
        {
            _responseCreator = responseCreator;
        }

        public IResponse Parse(string response)
        {
            var code = response.Substring(0, response.IndexOf(' '));
            var text = response.Substring(response.IndexOf(' '));
            return _responseCreator.Create(code, text);
        }
    }
}
