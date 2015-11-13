using NSmtp.Models;

namespace NSmtp
{
    public interface ISmtpCommandExecutor
    {
        IResponse Execute();
    }
}
