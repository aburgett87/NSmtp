using Moq;
using NUnit.Framework;
using NSmtp.Processors;
using NSmtp.Models;
using NSmtp.Enums;
using NSmtp;
using System.Net.Mail;
using System.Collections.Generic;

namespace NSmtpUnitTests
{
    [TestFixture]
    public class SmtpCommandExecutorTest
    {
        Mock<ICommandProcessor> _commandProcessor = new Mock<ICommandProcessor>();
        Mock<IMailInfo> _mailInfo = new Mock<IMailInfo>();

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void CanSendHello()
        {
            var commandList = new List<ICommand>
            {
                new HelloCommand("localhost"),
                new MailFromCommand("blah@blah.com")
            };

            _commandProcessor.Setup(cmd => cmd.Process(It.IsAny<HelloCommand>())).Returns(new OkResponse("from Moq"));
            _commandProcessor.Setup(cmd => cmd.Process(It.IsAny<MailFromCommand>())).Returns(new OkResponse("From Added"));

            var connectionSetup = new SmtpCommandExecutor(_commandProcessor.Object, commandList);
            var response = connectionSetup.Execute();
            Assert.That(response.ResponseCode, Is.EqualTo(SmtpResponseCode.OK));
            Assert.That(response.ResponseText, Is.EqualTo("From Added"));
            _commandProcessor.Verify(cmd => cmd.Process(It.IsAny<HelloCommand>()), Times.Once);
            _commandProcessor.Verify(cmd => cmd.Process(It.IsAny<MailFromCommand>()), Times.Once);
        }
    }
}
