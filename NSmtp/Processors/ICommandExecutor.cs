using NSmtp.Models.Responses;
using NSmtp.Models.Commands;
using System.Collections.Generic;

namespace NSmtp.Processors
{
    public interface ICommandExecutor
    {
        IResponse Execute(List<ICommand> commands);
    }
}
