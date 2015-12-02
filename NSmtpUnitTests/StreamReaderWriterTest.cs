using NUnit.Framework;
using NSmtp.Utilities;
using Moq;
using NSmtp;
using System.IO;

namespace NSmtpUnitTests
{
    [TestFixture]
    public class StreamReaderWriterTest
    {
        private Mock<IStreamManager> _streamManager;

        [SetUp]
        public void SetUp()
        {
            _streamManager = new Mock<IStreamManager>();
        }

        [Test]
        public void CanRetrieveStreamReader()
        {
            var stream = new Mock<Stream>();
            stream.Setup(str => str.CanRead).Returns(true);
            _streamManager.Setup(str => str.Retrieve()).Returns(stream.Object);
            var streamReaderWriter = new StreamReaderWriter(_streamManager.Object);
            var reader = streamReaderWriter.Reader;
            _streamManager.Verify(str => str.Retrieve(), Times.Once);
        }

        [Test]
        public void CanRetrieveStreamWriter()
        {
            var stream = new Mock<Stream>();
            stream.Setup(str => str.CanWrite).Returns(true);
            _streamManager.Setup(str => str.Retrieve()).Returns(stream.Object);
            var streamReaderWriter = new StreamReaderWriter(_streamManager.Object);
            var reader = streamReaderWriter.Writer;
            _streamManager.Verify(str => str.Retrieve(), Times.Once);
        }
    }
}
