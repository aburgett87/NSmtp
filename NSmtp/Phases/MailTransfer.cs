using System.Net.Mail;
using NSmtp.Enums;
using NSmtp.Parsers;
using NSmtp.Processors;
using NSmtp.Models.Responses;

namespace NSmtp.Phases
{
    public class MailTransfer : IMailTransfer
    {
        private readonly ICommandListCreator _commandListCreator;
        private readonly ICommandExecutor _commandExecutor;

        public MailTransfer(ICommandListCreator commandListCreator, ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
            _commandListCreator = commandListCreator;
        }

        public IResponse Execute(MailMessage mailMessage)
        {
            var commandList = _commandListCreator.Create(mailMessage);

            return _commandExecutor.Execute(commandList);
        }
    }
}
