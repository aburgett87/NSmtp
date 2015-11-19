using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class ReplyToCommand : ICommand
    {
        public ReplyToCommand(string text)
        {
            Argument = text;
        }

        public string Command
        {
            get { return SmtpCommands.ReplyTo; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
