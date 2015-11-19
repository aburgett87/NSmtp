using NSmtp.Models.Commands;
using System.Net.Mail;
using System.Collections.Generic;

namespace NSmtp.Converters
{
    public class MailMessageToRecipientConverter : IMailMessageConverter<List<RecipientCommand>>
    {

        public List<RecipientCommand> Convert(MailMessage mailMessage)
        {
            var recipientList = ConvertRecipient(mailMessage.To);
            recipientList.AddRange(ConvertRecipient(mailMessage.CC));
            recipientList.AddRange(ConvertRecipient(mailMessage.Bcc));
            return recipientList;

        }

        private List<RecipientCommand> ConvertRecipient(MailAddressCollection collection)
        {
            var recipientList = new List<RecipientCommand>();
            foreach (var recipient in collection)
            {
                recipientList.Add(new RecipientCommand("<" + recipient.Address + ">"));
            }

            return recipientList;
        }
    }
}
