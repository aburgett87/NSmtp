using NUnit.Framework;
using Moq;
using NSmtp.Processors;
using NSmtp.Converters;
using System.Collections.Generic;
using NSmtp.Models.Commands;
using NSmtp.Models;
using NSmtp;
using System.Net.Mail;
using System;

namespace NSmtpUnitTests
{
    [TestFixture]
    public class CommandListCreatorTest
    {
        Mock<IMailMessageConverter<List<RecipientCommand>>> _mailMessageToRecipient;
        Mock<IMailMessageConverter<DataBodyCommand>> _mailMessageToDataBody;
        Mock<IHostInfo> _hostInfo;

        [SetUp]
        public void SetUp()
        {
            _mailMessageToRecipient = new Mock<IMailMessageConverter<List<RecipientCommand>>>();
            _mailMessageToDataBody = new Mock<IMailMessageConverter<DataBodyCommand>>();
            _hostInfo = new Mock<IHostInfo>();
        }

        [Test]
        public void CanCreateList()
        {
            var mailMessage = new MailMessage("ab@ab.com", "ba@ba.com", "test", "testbody");
            _hostInfo.Setup(host => host.Host).Returns("localhost");
            _mailMessageToDataBody.Setup(dataBody => dataBody.Convert(mailMessage)).Returns(new DataBodyCommand("test\r\n\r\n.\r\n"));
            _mailMessageToRecipient.Setup(conv => conv.Convert(mailMessage)).Returns(new List<RecipientCommand> { new RecipientCommand("<ba@ba.com>") });
            var commandListCreator = new CommandListCreator(_hostInfo.Object, _mailMessageToRecipient.Object, _mailMessageToDataBody.Object);
            var commandList = commandListCreator.Create(mailMessage);

            Assert.That(commandList[0].Command, Is.EqualTo("HELO"));
            Assert.That(commandList[0].Argument, Is.EqualTo("localhost"));
            Assert.That(commandList[1].Command, Is.EqualTo("MAIL FROM:"));
            Assert.That(commandList[1].Argument, Is.EqualTo("<ab@ab.com>"));
            Assert.That(commandList[2].Command, Is.EqualTo("RCPT TO:"));
            Assert.That(commandList[3].Command, Is.EqualTo("DATA"));
            Assert.That(commandList[4].Command, Is.EqualTo("test\r\n\r\n.\r\n"));
            Assert.That(commandList[4].Argument, Is.EqualTo(String.Empty));
        }
    }
}
