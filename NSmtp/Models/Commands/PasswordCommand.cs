using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class PasswordCommand: ICommand
    {
        public PasswordCommand(string password)
        {
            Command = password;
        }

        public string Command
        {
            get;
            private set;
        }

        public string Argument
        {
            get { return String.Empty; }
        }
    }
}
