using System.IO;

namespace NSmtp
{
    public interface IStreamReaderWriter
    {
        TextReader Reader { get; }
        TextWriter Writer { get; }
    }
}
