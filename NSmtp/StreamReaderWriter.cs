using System.IO;
using System.Text;

namespace NSmtp
{
    public class StreamReaderWriter : IStreamReaderWriter
    {
        private readonly Stream _stream;
        public StreamReaderWriter(Stream stream)
        {
            _stream = stream;
        }

        public TextReader Reader
        {
            get { return new StreamReader(_stream, Encoding.UTF8); }
        }

        public TextWriter Writer
        {
            get { return new StreamWriter(_stream, Encoding.ASCII) { AutoFlush = true, NewLine = "\r\n" }; }
        }
    }
}
