using NSmtp.Models.DataFields;
using NSmtp;
using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace NSmtp.Converters
{
    public class AttachmentConverter : IMailMessageConverter<List<AttachmentDataFiled>>
    {
        public List<AttachmentDataFiled> Convert(MailMessage mailMessage)
        {
            List<AttachmentDataFiled> attachmentList = new List<AttachmentDataFiled>();

            if (mailMessage.Attachments.Count == 0)
                return attachmentList;
			
            foreach (var attachement in mailMessage.Attachments)
            {
				var buffer = new byte[attachement.ContentStream.Length];
				attachement.ContentStream.Read (buffer, 0, buffer.Length);
				var data = System.Convert.ToBase64String (buffer, Base64FormattingOptions.InsertLineBreaks);
				var heading = new BoundaryDataField(DataFieldHeadings.AttatchmentBoundary).Content + "\r\n";
                heading += DataFieldHeadings.ContentType + attachement.ContentType.ToString() + "\r\n";
                heading += "Content-Transfer-Encoding: " + attachement.TransferEncoding.ToString() + "\r\n";
                heading += "Content-ID: " + attachement.ContentId + "\r\n";
                heading += "Conent-Disposition: " + attachement.ContentDisposition.DispositionType + "; filename=" + attachement.Name + "\r\n";
                heading += "\r\n";
                attachmentList.Add(new AttachmentDataFiled(heading, data));
            }
            return attachmentList;
        }
    }
}
