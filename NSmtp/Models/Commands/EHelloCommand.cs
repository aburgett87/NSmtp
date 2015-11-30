using NSmtp;

namespace NSmtp.Models.Commands
{
    public class EHelloCommand : ICommand
    {
        public EHelloCommand(string argument)
        {
            Argument = argument;
        }

        public string Command
        {
            get { return SmtpCommands.EHello; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
