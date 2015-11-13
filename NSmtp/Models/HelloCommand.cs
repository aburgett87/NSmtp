using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models
{
    public class HelloCommand : ICommand
    {
        public HelloCommand(string argument)
        {
            Argument = argument;
        }

        public string Command
        {
            get
            {
                return SmtpCommands.Hello;
            }
        }

        public string Argument { get; private set; }

    }
}
