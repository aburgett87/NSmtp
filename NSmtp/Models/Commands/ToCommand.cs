using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class ToCommand : ICommand
    {
        public ToCommand(string text)
        {
            Argument = text;
        }

        public string Command
        {
            get { return SmtpCommands.To; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
