using NSmtp.Models.DataFields;
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
            foreach (var attatchement in mailMessage.Attachments)
            {
                string data = new StreamReader(
                    new CryptoStream(attatchement.ContentStream, 
                        new ToBase64Transform(), CryptoStreamMode.Read)).ReadToEnd();

                string heading = attatchement.ContentType.ToString() + "\r\n";
                heading += "Content-Transfer-Encoding: " + attatchement.TransferEncoding.ToString() + "\r\n";
                heading += "Content-ID: " + attatchement.ContentId + "\r\n";
                heading += "Conent-Disposition: " + attatchement.ContentDisposition.DispositionType + "; filename=" + attatchement.Name + "\r\n";
                attachmentList.Add(new AttachmentDataFiled(heading, data));
            }
            return attachmentList;
        }
    }
}
