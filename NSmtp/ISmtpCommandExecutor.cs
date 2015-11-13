using NSmtp.Models;
using System.Collections.Generic;

namespace NSmtp
{
    public interface ISmtpCommandExecutor
    {
        IResponse Execute(IList<ICommand> commands);
    }
}
