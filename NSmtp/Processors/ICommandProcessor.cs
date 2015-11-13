using NSmtp.Models;

namespace NSmtp.Processors
{
    public interface ICommandProcessor
    {
        IResponse Process(ICommand command);
    }
}
