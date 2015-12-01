using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class AuthCommand : ICommand
    {
        public AuthCommand(string arugment)
        {
            Argument = arugment;
        }

        public string Command
        {
            get { return SmtpCommands.Auth; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
