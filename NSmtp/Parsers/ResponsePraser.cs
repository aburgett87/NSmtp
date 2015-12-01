using NSmtp.Models.Responses;

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
            var code = response.Substring(0, 3);
            var text = response.Substring(4);
            return _responseCreator.Create(code, text);
        }
    }
}
