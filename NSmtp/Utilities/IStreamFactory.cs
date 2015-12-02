using System.IO;
using NSmtp.Models;

namespace NSmtp.Utilities
{
    public interface IStreamFactory
    {
        Stream Create();
    }
}
