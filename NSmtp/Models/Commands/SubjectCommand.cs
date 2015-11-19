using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class SubjectCommand : ICommand
    {
        public SubjectCommand(string text)
        {
            Argument = text;
        }

        public string Command
        {
            get { return SmtpCommands.Subject; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
