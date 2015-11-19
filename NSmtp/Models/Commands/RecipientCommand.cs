using NSmtp;

namespace NSmtp.Models.Commands
{
    public class RecipientCommand: ICommand
    {
        public RecipientCommand(string argument)
        {
            Argument = argument;
        }

        public string Command
        {
            get { return SmtpCommands.Recipient; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
