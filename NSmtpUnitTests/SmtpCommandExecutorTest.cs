using Moq;
using NUnit.Framework;
using NSmtp.Processors;
using NSmtp.Parsers;
using NSmtp.Models.Commands;
using NSmtp.Models.Responses;
using NSmtp.Enums;
using NSmtp;
using System.Net.Mail;
using System.Collections.Generic;

namespace NSmtpUnitTests
{
    [TestFixture]
    public class SmtpCommandExecutorTest
    {
        Mock<ICommandProcessor> _commandProcessor;
        Mock<ISuccessfulCommandToResponseFactory> _successResponseFactory;

        [SetUp]
        public void SetUp()
        {
            _commandProcessor = new Mock<ICommandProcessor>();
            _successResponseFactory = new Mock<ISuccessfulCommandToResponseFactory>();
        }

        [Test]
        public void CanExecuteCommands()
        {
            var commandList = new List<ICommand>
            {
                new HelloCommand("localhost"),
                new MailFromCommand("blah@blah.com")
            };

            _commandProcessor.Setup(cmd => cmd.Process(It.IsAny<HelloCommand>())).Returns(new OkResponse("from Moq"));
            _commandProcessor.Setup(cmd => cmd.Process(It.IsAny<MailFromCommand>())).Returns(new OkResponse("From Added"));
            _successResponseFactory.Setup(fact => fact.CreateResponseList(It.IsAny<string>())).Returns(new List<SmtpResponseCode> { SmtpResponseCode.OK });

            var connectionSetup = new CommandExecutor(_commandProcessor.Object, _successResponseFactory.Object);
            var response = connectionSetup.Execute(commandList);
            Assert.That(response.ResponseCode, Is.EqualTo(SmtpResponseCode.OK));
            Assert.That(response.ResponseText, Is.EqualTo("From Added"));
            _commandProcessor.Verify(cmd => cmd.Process(It.IsAny<HelloCommand>()), Times.Once);
            _commandProcessor.Verify(cmd => cmd.Process(It.IsAny<MailFromCommand>()), Times.Once);
        }
    }
}
