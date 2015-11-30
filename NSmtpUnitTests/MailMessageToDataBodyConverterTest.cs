using NSmtp;
using NSmtp.Converters;
using NUnit.Framework;
using System.Net.Mail;

namespace NSmtpUnitTests
{
    [TestFixture]
    public class MailMessageToDataBodyConverterTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void CanCovertFromField()
        {
            var converter = new MailMessageToDataBodyCommandConverter();
            var msg = new MailMessage("blah@blah", "blue@blah", "test", "testbody");
            var command = converter.Convert(msg);
            Assert.That(command.Command, Is.StringContaining("FROM: blah@blah\r\n"));
        }

        [Test]
        public void CanCovertToField()
        {
            var converter = new MailMessageToDataBodyCommandConverter();
            var msg = new MailMessage("blah@blah", "blue@blah", "test", "testbody");
            var command = converter.Convert(msg);
            Assert.That(command.Command, Is.StringContaining("TO: blue@blah\r\n"));
        }

        [Test]
        public void CanCovertSubjectField()
        {
            var converter = new MailMessageToDataBodyCommandConverter();
            var msg = new MailMessage("blah@blah", "blue@blah", "test", "testbody");
            var command = converter.Convert(msg);
            Assert.That(command.Command, Is.StringContaining("SUBJECT: test\r\n"));
        }

        [Test]
        public void CanCovertBodyField()
        {
            var converter = new MailMessageToDataBodyCommandConverter();
            var msg = new MailMessage("blah@blah", "blue@blah", "test", "testbody");
            var command = converter.Convert(msg);
            Assert.That(command.Command, Is.StringContaining("testbody\r\n"));
        }

        [Test]
        public void CanCovertHtmlBodyField()
        {
            var converter = new MailMessageToDataBodyCommandConverter();
            var msg = new MailMessage("blah@blah", "blue@blah", "test", "<html><body>testbody</body></html>");
            msg.IsBodyHtml = true;
            var command = converter.Convert(msg);
            Assert.That(command.Command, Is.StringContaining("<html><body>testbody</body></html>"));
        }
    }
}
