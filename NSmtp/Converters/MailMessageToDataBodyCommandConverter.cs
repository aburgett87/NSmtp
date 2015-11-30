using NSmtp.Models.Commands;
using System.Net.Mail;
using System.Collections.Generic;
using System;

namespace NSmtp.Converters
{
    public class MailMessageToDataBodyCommandConverter : IMailMessageConverter<DataBodyCommand>
    {
        public DataBodyCommand Convert(MailMessage mailMessage)
        {
            var headers = "";

            foreach(var key in mailMessage.Headers.AllKeys)
            {
                headers += key + ": " + mailMessage.Headers[key] + "\r\n";
            }

            var dataCommandList = new List<ICommand>
            {
                new DateCommand(DateTime.Now.ToLongDateString()), //move to mockable dependency
                new FromCommand(mailMessage.From.Address),
                new ToCommand(mailMessage.To.ToString()),
                new CcCommand(mailMessage.CC.ToString()),
                new BccCommand(mailMessage.Bcc.ToString()),
                new ReplyToCommand(mailMessage.ReplyToList.ToString()),
                new SubjectCommand(mailMessage.Subject),
                new CRLFCommand(),
                new BodyCommand(mailMessage.Body),
                new CRLFCommand(),
                new DataStopCommand()
            };

            var dataBodyCommand = "";

            foreach (var command in dataCommandList)
            {
                dataBodyCommand += command.Command + command.Argument + "\r\n";
            }

            return new DataBodyCommand(dataBodyCommand);
        }
    }
}
