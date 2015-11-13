using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models
{
    public interface ICommand
    {
        string Command { get; }
        string Argument { get; }
    }
}
