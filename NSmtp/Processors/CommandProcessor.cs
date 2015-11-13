using NSmtp.Models;
using NSmtp.Enums;
using NSmtp.Parsers;

namespace NSmtp.Processors
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IStreamReaderWriter _streamReaderWriter;
        private readonly IResponseParser _responseParser;

        public CommandProcessor(IStreamReaderWriter streamReaderWriter, IResponseParser responseParser)
        {
            _streamReaderWriter = streamReaderWriter;
            _responseParser = responseParser;
        }
        public IResponse Process(ICommand command)
        {
            _streamReaderWriter.Writer.WriteLine(command.Command + " " + command.Argument);
            return _responseParser.Parse(_streamReaderWriter.Reader.ReadLine());
        }
    }
}
