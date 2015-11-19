namespace NSmtp.Models.Commands
{
    public class BccCommand : ICommand
    {
        public BccCommand(string text)
        {
            Argument = text;
        }

        public string Command
        {
            get { return SmtpCommands.Bcc; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
