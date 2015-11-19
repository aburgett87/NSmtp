using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class DataStopCommand : ICommand
    {

        public string Command
        {
            get { return SmtpCommands.DataStop; }
        }

        public string Argument
        {
            get { return String.Empty; }
        }
    }
}
