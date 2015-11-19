using NSmtp.Processors;
using NSmtp.Models.Commands;
using NSmtp.Enums;
using NSmtp.Parsers;
using NSmtp.Models.Responses;
using System.Net.Mail;
using System.Collections.Generic;

namespace NSmtp.Processors
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly ISuccessfulCommandToResponseFactory _commandToResponseFactory;
        public CommandExecutor(ICommandProcessor commandProcessor, ISuccessfulCommandToResponseFactory commandToResponseFactory)
        {
            _commandProcessor = commandProcessor;
            _commandToResponseFactory = commandToResponseFactory;
        }

        public IResponse Execute(List<ICommand> commandList)
        {
            IResponse response = new OkResponse("");
            foreach (var command in commandList)
            {
                var successfulResponseList = _commandToResponseFactory.CreateResponseList(command.Command);
                response = _commandProcessor.Process(command);
                if (!successfulResponseList.Contains(response.ResponseCode))
                    return response;
            }
            return response;
        }
    }
}
