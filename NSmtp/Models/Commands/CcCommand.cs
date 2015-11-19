using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class CcCommand : ICommand
    {
        public CcCommand(string text)
        {
            Argument = text;
        }

        public string Command
        {
            get { return SmtpCommands.Cc; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
