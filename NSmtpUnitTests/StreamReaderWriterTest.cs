using NUnit.Framework;
using Moq;
using NSmtp;
using System.IO;

namespace NSmtpUnitTests
{
    [TestFixture]
    public class StreamReaderWriterTest
    {
        private Mock<Stream> _stream;

        [SetUp]
        public void SetUp()
        {
            _stream = new Mock<Stream>();
        }

        [Test]
        public void CanRetrieveStreamReader()
        {
            _stream.Setup(str => str.CanRead).Returns(true);
            var streamReaderWriter = new StreamReaderWriter(_stream.Object);
            var reader = streamReaderWriter.Reader;
            _stream.Verify(str => str.CanRead, Times.Once);
        }

        [Test]
        public void CanRetrieveStreamWriter()
        {
            _stream.Setup(str => str.CanWrite).Returns(true);
            var streamReaderWriter = new StreamReaderWriter(_stream.Object);
            var writer = streamReaderWriter.Writer;
            _stream.Verify(str => str.CanWrite, Times.Once);
        }
    }
}
