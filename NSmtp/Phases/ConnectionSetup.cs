using NSmtp.Models.Responses;
using NSmtp.Parsers;

namespace NSmtp.Phases
{
    public class ConnectionSetup : IConnectionSetup
    {
        private readonly IStreamReaderWriter _streamReaderWriter;
        private readonly IResponseParser _responseParser;

        public ConnectionSetup(IStreamReaderWriter streamReaderWriter, IResponseParser responseParser)
        {
            _streamReaderWriter = streamReaderWriter;
            _responseParser = responseParser;
        }

        public IResponse Setup()
        {
            return _responseParser.Parse(_streamReaderWriter.Reader.ReadLine());
        }
    }
}
