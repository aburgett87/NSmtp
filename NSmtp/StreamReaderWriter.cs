using System.IO;
using System.Text;
using NSmtp.Utilities;

namespace NSmtp
{
    public class StreamReaderWriter : IStreamReaderWriter
    {
        private readonly IStreamManager _streamManager;
        public StreamReaderWriter(IStreamManager streamManager)
        {
            _streamManager = streamManager;
        }

        public TextReader Reader
        {
            get { return new StreamReader(_streamManager.Retrieve(), Encoding.UTF8); }
        }

        public TextWriter Writer
        {
            get { return new StreamWriter(_streamManager.Retrieve(), Encoding.ASCII) { AutoFlush = true, NewLine = "\r\n" }; }
        }
    }
}
