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
        IList<ICommand> _commandList;

        public SmtpCommandExecutor(ICommandProcessor commandProcessor, IList<ICommand> commandList)
        {
            _commandProcessor = commandProcessor;
            _commandList = commandList;
        }

        public IResponse Execute()
        {
            IResponse response = new OkResponse("");
            foreach (var command in _commandList)
            {
                response = _commandProcessor.Process(command);

                if (response.ResponseCode != SmtpResponseCode.OK)
                    return response;
            }
            return response;
        }
    }
}
