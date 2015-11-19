using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class QuitCommand : ICommand
    {
        public string Command
        {
            get { return SmtpCommands.Quit; }
        }

        public string Argument
        {
            get { return String.Empty; }
        }
    }
}
