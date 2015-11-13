using NSmtp;

namespace NSmtp.Models
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
