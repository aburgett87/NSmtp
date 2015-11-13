using NSmtp.Processors;
using NSmtp.Models;
using NSmtp.Enums;
using System.Net.Mail;
using System.Collections.Generic;

namespace NSmtp
{
    public class SmtpCommandExecutor : ISmtpCommandExecutor
    {
        private readonly ICommandProcessor _commandProcessor;

        public SmtpCommandExecutor(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public IResponse Execute(IList<ICommand> commandList)
        {
            IResponse response = new OkResponse("");
            foreach (var command in commandList)
            {
                response = _commandProcessor.Process(command);

                if (response.ResponseCode != SmtpResponseCode.OK)
                    return response;
            }
            return response;
        }
    }
}
