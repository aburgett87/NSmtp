using NSmtp.Models.Commands;
using NSmtp.Models.DataFields;
using System.Net.Mail;
using System.Collections.Generic;
using System;

namespace NSmtp.Converters
{
    public class MailMessageToDataBodyCommandConverter : IMailMessageConverter<DataBodyCommand>
    {
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
                new CRLFDataField(),
                new BodyDataField(mailMessage.Body),
                new CRLFDataField(),
                new DataStopDataField()
            };

            var dataField = "";

            foreach (var field in dataFieldList)
            {
                dataField += field.Heading + field.Content + "\r\n";
            }

            return new DataBodyCommand(dataField);
        }
    }
}
