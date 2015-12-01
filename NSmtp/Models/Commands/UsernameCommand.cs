using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class UsernameCommand : ICommand
    {
        public UsernameCommand(string username)
        {
            Command = username;
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
