using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class DataCommand : ICommand
    {
        public string Command
        {
            get { return SmtpCommands.Data; }
        }

        public string Argument
        {
            get { return String.Empty; }
        }
    }
}
