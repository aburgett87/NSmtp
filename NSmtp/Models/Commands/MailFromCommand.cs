using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class MailFromCommand : ICommand
    {
        public MailFromCommand(string fromList)
        {
            Argument = fromList;
        }

        public string Command
        {
            get { return SmtpCommands.MailFrom; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
