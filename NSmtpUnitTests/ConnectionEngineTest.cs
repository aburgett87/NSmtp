using NUnit.Framework;
using Moq;
using NSmtp.Processors;
using NSmtp;
using NSmtp.Phases;
using NSmtp.Models.Responses;
using NSmtp.Enums;
using System.Net.Mail;

namespace NSmtpUnitTests
{
    [TestFixture]
    public class ConnectionEngineTest
    {
        private Mock<IConnectionSetup> _connectionSetup;
        private Mock<IMailTransfer> _mailTransfer;
        private Mock<IConnectionTermination> _connectionTermination;

        [SetUp]
        public void SetUp()
        {
            _connectionSetup = new Mock<IConnectionSetup>();
            _mailTransfer = new Mock<IMailTransfer>();
            _connectionTermination = new Mock<IConnectionTermination>();
        }

        [Test]
        public void CanRunEngineThroughAllPhases()
        {
            var message = new MailMessage("ab@ab.com", "ba@ba.com");
            _connectionSetup.Setup(setup => setup.Setup()).Returns(new ServiceReadyResponse("service ready"));
            _mailTransfer.Setup(trans => trans.Execute(message)).Returns(new OkResponse("ok")).Verifiable();
            _connectionTermination.Setup(term => term.Terminate()).Returns(new ClosingTransmissionChannelResponse("closing")).Verifiable();
            var engine = new ConnectionEngine(_connectionSetup.Object, _mailTransfer.Object, _connectionTermination.Object);
            var response = engine.Execute(message);
            Assert.That(response.ResponseCode, Is.EqualTo(SmtpResponseCode.ClosingTransmissionChannel));
            Assert.That(response.ResponseText, Is.EqualTo("closing"));
            _connectionSetup.Verify(setup => setup.Setup(), Times.Once);
            _mailTransfer.Verify(trans => trans.Execute(message), Times.Once);
            _connectionTermination.Verify(term => term.Terminate(), Times.Once);
        }
    }
}
