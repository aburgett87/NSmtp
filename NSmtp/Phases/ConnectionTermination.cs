using NSmtp.Models.Responses;
using NSmtp.Models.Commands;
using System.Collections.Generic;
using NSmtp.Processors;

namespace NSmtp.Phases
{
    public class ConnectionTermination : IConnectionTermination
    {
        private readonly ICommandExecutor _smtpCommandExecutor;

        public ConnectionTermination(ICommandExecutor smtpCommandExecutor)
        {
            _smtpCommandExecutor = smtpCommandExecutor;
        }

        public IResponse Terminate()
        {
            return _smtpCommandExecutor.Execute(
                new List<ICommand>
                {
                    new QuitCommand()
                });
        }
    }
}
