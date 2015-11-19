using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.Commands
{
    public class BodyCommand : ICommand
    {
        public BodyCommand(string text)
        {
            Argument = text;
        }

        public string Command
        {
            get { return String.Empty; }
        }

        public string Argument
        {
            get;
            private set;
        }
    }
}
