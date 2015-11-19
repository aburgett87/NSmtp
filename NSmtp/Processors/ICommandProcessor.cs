using NSmtp.Models.Responses;
using NSmtp.Models.Commands;

namespace NSmtp.Processors
{
    public interface ICommandProcessor
    {
        IResponse Process(ICommand command);
    }
}
