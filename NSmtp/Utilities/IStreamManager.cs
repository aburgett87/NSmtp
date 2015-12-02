using System.IO;

namespace NSmtp.Utilities
{
    public interface IStreamManager
    {
        void Add(Stream stream);
        Stream Retrieve();
        void Close();
    }
}
