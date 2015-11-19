using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class FromCommand : ICommand
    {
        public FromCommand(string text)
        {
            Argument = text;
        }

        public string Command
        {
            get { return SmtpCommands.From; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
