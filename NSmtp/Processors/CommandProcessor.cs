using NSmtp.Models.Responses;
using NSmtp.Models.Commands;
using NSmtp.Enums;
using NSmtp.Parsers;
using System;

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
            _streamReaderWriter.Writer.WriteLine(CreateCommandString(command));
            return _responseParser.Parse(_streamReaderWriter.Reader.ReadLine());
        }

        private string CreateCommandString(ICommand command) //make a dependency?
        {
            string commandString = command.Command;
            if (!String.IsNullOrWhiteSpace(command.Argument))
                commandString += " " + command.Argument;
            System.Diagnostics.Debug.WriteLine(commandString);
            return commandString;
        }
    }
}
