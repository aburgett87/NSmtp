using Moq;
using NSmtp;
using NSmtp.Converters;
using NUnit.Framework;
using System.Net.Mail;

namespace NSmtpUnitTests
{
    [TestFixture]
    public class MailMessageToRecipientConverterTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void CanGenerateRecipients()
        {
            var converter = new MailMessageToRecipientConverter();
            var message = new MailMessage();
            message.To.Add(new MailAddress("ab@ba.com"));
            message.To.Add(new MailAddress("another@here.com"));
            message.CC.Add(new MailAddress("cc@do-do.com"));
            message.Bcc.Add(new MailAddress("bcc@do-do.com"));
            var commandList = converter.Convert(message);
            Assert.That(commandList[0].Argument, Is.EqualTo("<ab@ba.com>"));
            Assert.That(commandList[0].Command, Is.EqualTo("RCPT TO:"));
            Assert.That(commandList[1].Argument, Is.EqualTo("<another@here.com>"));
            Assert.That(commandList[1].Command, Is.EqualTo("RCPT TO:"));
            Assert.That(commandList[2].Argument, Is.EqualTo("<cc@do-do.com>"));
            Assert.That(commandList[2].Command, Is.EqualTo("RCPT TO:"));
            Assert.That(commandList[3].Argument, Is.EqualTo("<bcc@do-do.com>"));
            Assert.That(commandList[3].Command, Is.EqualTo("RCPT TO:"));
        }
    }
}
