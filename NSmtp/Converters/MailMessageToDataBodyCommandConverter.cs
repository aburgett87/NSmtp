using NSmtp.Models.Commands;
using NSmtp.Models.DataFields;
using System.Net.Mail;
using System.Collections.Generic;
using System;

namespace NSmtp.Converters
{
    public class MailMessageToDataBodyCommandConverter : IMailMessageConverter<DataBodyCommand>
    {
        public IMailMessageConverter<List<AttachmentDataFiled>> _attachmentConverter;

        public MailMessageToDataBodyCommandConverter(IMailMessageConverter<List<AttachmentDataFiled>> attachmentConverter)
        {
            _attachmentConverter = attachmentConverter;
        }

        public DataBodyCommand Convert(MailMessage mailMessage)
        {
            var dataFieldList = new List<IDataField>
            {
                new DateDataField(DateTime.Now.ToLongDateString()), //move to mockable dependency
                new FromDataField(mailMessage.From.Address),
                new ToDataField(mailMessage.To.ToString()),
                new CcDataField(mailMessage.CC.ToString()),
                new BccDataField(mailMessage.Bcc.ToString()),
                new ReplyToDataField(mailMessage.ReplyToList.ToString()),
                new SubjectDataField(mailMessage.Subject),
                new MimeVersionDataField("1.0"),
                new ContentTypeDataField(@"multipart/mixed; boundary=" + DataFieldHeadings.TextBoundary),
                new EmptyDataField()
            };

            dataFieldList.AddRange(new List<IDataField>
            {
                new BoundaryDataField(DataFieldHeadings.TextBoundary),
                new ContentTypeDataField(@"text/plain"),
                new EmptyDataField(),
                new BodyDataField(mailMessage.Body),
            });

            var attachmentList = _attachmentConverter.Convert(mailMessage);
            if (attachmentList.Count > 0)
            {
                dataFieldList.Add(new BoundaryDataField(DataFieldHeadings.TextBoundary));
                dataFieldList.Add(new ContentTypeDataField(@"multipart/related; boundary=" + DataFieldHeadings.AttatchmentBoundary));
                dataFieldList.Add(new EmptyDataField());
                dataFieldList.AddRange(attachmentList);
                dataFieldList.Add(new BoundaryEndDataField(DataFieldHeadings.AttatchmentBoundary));
            }

            dataFieldList.AddRange(new List<IDataField>
            {
                new BoundaryEndDataField(DataFieldHeadings.TextBoundary),
                new EmptyDataField(),
            });

            var dataField = "";

            foreach (var field in dataFieldList)
            {
                dataField += field.Heading + field.Content + "\r\n";
            }
            dataField += SmtpCommands.DataStop;

            return new DataBodyCommand(dataField);
        }
    }
}
