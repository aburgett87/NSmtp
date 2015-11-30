using Moq;
using NSmtp;
using NSmtp.Converters;
using NSmtp.Models.DataFields;
using NUnit.Framework;
using System.Net.Mail;
using System.Collections.Generic;

namespace NSmtpUnitTests
{
    [TestFixture]
    public class MailMessageToDataBodyConverterTest
    {
        Mock<IMailMessageConverter<List<AttachmentDataFiled>>> _attachmentConverter;

        [SetUp]
        public void SetUp()
        {
            _attachmentConverter = new Mock<IMailMessageConverter<List<AttachmentDataFiled>>>();
        }

        [Test]
        public void CanCovertFromField()
        {
            _attachmentConverter.Setup(conv => conv.Convert(It.IsAny<MailMessage>())).Returns(new List<AttachmentDataFiled>());
            var converter = new MailMessageToDataBodyCommandConverter(_attachmentConverter.Object);
            var msg = new MailMessage("blah@blah", "blue@blah", "test", "testbody");
            var command = converter.Convert(msg);
            Assert.That(command.Command, Is.StringContaining("FROM: blah@blah\r\n"));
        }

        [Test]
        public void CanCovertToField()
        {
            _attachmentConverter.Setup(conv => conv.Convert(It.IsAny<MailMessage>())).Returns(new List<AttachmentDataFiled>());
            var converter = new MailMessageToDataBodyCommandConverter(_attachmentConverter.Object);
            var msg = new MailMessage("blah@blah", "blue@blah", "test", "testbody");
            var command = converter.Convert(msg);
            Assert.That(command.Command, Is.StringContaining("TO: blue@blah\r\n"));
        }

        [Test]
        public void CanCovertSubjectField()
        {
            _attachmentConverter.Setup(conv => conv.Convert(It.IsAny<MailMessage>())).Returns(new List<AttachmentDataFiled>());
            var converter = new MailMessageToDataBodyCommandConverter(_attachmentConverter.Object);
            var msg = new MailMessage("blah@blah", "blue@blah", "test", "testbody");
            var command = converter.Convert(msg);
            Assert.That(command.Command, Is.StringContaining("SUBJECT: test\r\n"));
        }

        [Test]
        public void CanCovertBodyField()
        {
            _attachmentConverter.Setup(conv => conv.Convert(It.IsAny<MailMessage>())).Returns(new List<AttachmentDataFiled>());
            var converter = new MailMessageToDataBodyCommandConverter(_attachmentConverter.Object);
            var msg = new MailMessage("blah@blah", "blue@blah", "test", "testbody");
            var command = converter.Convert(msg);
            Assert.That(command.Command, Is.StringContaining("testbody\r\n"));
        }

        [Test]
        public void CanCovertHtmlBodyField()
        {
            _attachmentConverter.Setup(conv => conv.Convert(It.IsAny<MailMessage>())).Returns(new List<AttachmentDataFiled>());
            var converter = new MailMessageToDataBodyCommandConverter(_attachmentConverter.Object);
            var msg = new MailMessage("blah@blah", "blue@blah", "test", "<html><body>testbody</body></html>");
            msg.IsBodyHtml = true;
            var command = converter.Convert(msg);
            Assert.That(command.Command, Is.StringContaining("<html><body>testbody</body></html>"));
        }
    }
}
