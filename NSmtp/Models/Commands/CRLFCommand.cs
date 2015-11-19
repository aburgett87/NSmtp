using System;
namespace NSmtp.Models.Commands
{
    public class CRLFCommand : ICommand
    {
        public string Command
        {
            get { return String.Empty; }
        }

        public string Argument
        {
            get { return String.Empty; }
        }
    }
}
