using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class DateCommand : ICommand
    {
        public DateCommand(string text)
        {
            Argument = text;
        }

        public string Command
        {
            get { return SmtpCommands.Date; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
