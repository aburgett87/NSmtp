using NSmtp.Models;

namespace NSmtp
{
    public interface IStreamCreator
    {
        IStreamReaderWriter Create(IHostInfo hostInfo);
    }
}
