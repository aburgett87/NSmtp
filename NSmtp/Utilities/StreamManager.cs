using System.IO;

namespace NSmtp.Utilities
{
    public class StreamManager : IStreamManager
    {
        private Stream _stream;

        public void Add(Stream stream)
        {
            _stream = stream;
        }

        public Stream Retrieve()
        {
            return _stream;
        }

        public void Close()
        {
            _stream.Close();
        }
    }
}
