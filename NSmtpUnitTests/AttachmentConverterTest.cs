using NSmtp.Models;
using NSmtp.Converters;
using NUnit.Framework;
using Moq;
using System.Net.Mail;

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
            message.Attachments.Add(new Attachment(@"Resources\ImageAttachment.png"));
            var attachmentList = converter.Convert(message);
            Assert.That(attachmentList[0].Content, Is.StringContaining("iVBORw0KGgoAAAANSUhEUgAAAC8AAAAPCAIAAAD76QHNAAAAAXNSR0I" + 
                "Ars4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACiSURBVEhL7Y5BCsQwDAP7" + 
                "/09nReV4ZbmlhYalh53TSDIk23gTb/3NthNhxxrGJNqlHDwWuf5GHVi85Oa9P0C06Q4sXnLz3h8g2nQ3OB3SD/" + 
                "o9b8g35NaFMILIEy2fOBCbQxeFJYhcz544EJOBTtgYOq1yICYDnWhDBxpXORCzYaKRDjSuciBWB2ANYxJtPTt" + 
                "zkJGScCUl/Ib+ieT/m7PfjPEBMJkAVZvC8ugAAAAASUVORK5CYII="));
        }

        [Test]
        public void CanAttachTextFile()
        {
            var converter = new AttachmentConverter();
            var message = new MailMessage("blah@blah", "blah@blah");
            message.Attachments.Add(new Attachment(@"Resources\TextAttachment.txt"));
            var attachmentList = converter.Convert(message);
            Assert.That(attachmentList[0].Content, Is.StringContaining("77u/VGVzdA=="));
        }
    }
}
