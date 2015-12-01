using NSmtp.Models;
using NSmtp.Converters;
using NUnit.Framework;
using Moq;
using System.Net.Mail;
using System.IO;

namespace NSmtpUnitTests
{
    [TestFixture]
    public class AttachmentConverterTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void CanAttachBinaryFile()
        {
            var converter = new AttachmentConverter();
            var message = new MailMessage("blah@blah", "blah@blah");
			message.Attachments.Add(new Attachment(Path.Combine("Resources", "ImageAttachment.png")));
            var attachmentList = converter.Convert(message);
			var expectedString = "iVBORw0KGgoAAAANSUhEUgAAAC8AAAAPCAIAAAD76QHNAAAAAXNSR0IArs4c6QAAAARnQU1BAACx\r\n" +
				"jwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACiSURBVEhL7Y5BCsQwDAP7/09nReV4ZbmlhYal\r\n" +
				"h53TSDIk23gTb/3NthNhxxrGJNqlHDwWuf5GHVi85Oa9P0C06Q4sXnLz3h8g2nQ3OB3SD/o9b8g3\r\n" +
				"5NaFMILIEy2fOBCbQxeFJYhcz544EJOBTtgYOq1yICYDnWhDBxpXORCzYaKRDjSuciBWB2ANYxJt\r\n" +
				"PTtzkJGScCUl/Ib+ieT/m7PfjPEBMJkAVZvC8ugAAAAASUVORK5CYII=";
			Assert.That(attachmentList[0].Content, Is.EqualTo(expectedString));
        }

        [Test]
        public void CanAttachTextFile()
        {
            var converter = new AttachmentConverter();
            var message = new MailMessage("blah@blah", "blah@blah");
			message.Attachments.Add(new Attachment(Path.Combine("Resources","TextAttachment.txt")));
            var attachmentList = converter.Convert(message);
            Assert.That(attachmentList[0].Content, Is.StringContaining("77u/VGVzdA=="));
        }
    }
}
