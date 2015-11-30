using System;
using System.Collections.Generic;
using System.Net.Mail;
using NSmtp.Models;
using NSmtp.Converters;
using NSmtp.Models.Commands;

namespace NSmtp
{
    public class CommandListCreator : ICommandListCreator
    {
        private readonly IMailMessageConverter<List<RecipientCommand>> _recipientConverter;
        private readonly IHostInfo _hostInfo;
        private readonly IMailMessageConverter<DataBodyCommand> _dataCommandConverter;

        public CommandListCreator(IHostInfo hostInfo, 
            IMailMessageConverter<List<RecipientCommand>> recipientConverter,
            IMailMessageConverter<DataBodyCommand> dataCommandConverter)
        {
            _recipientConverter = recipientConverter;
            _hostInfo = hostInfo;
            _dataCommandConverter = dataCommandConverter;
        }

        public List<ICommand> Create(MailMessage mailMessage)
        {
            var commandList = new List<ICommand>();
            commandList.Add(new HelloCommand(_hostInfo.Host));
            commandList.Add(new MailFromCommand(mailMessage.From.Address));
            commandList.AddRange(_recipientConverter.Convert(mailMessage));
            commandList.Add(new DataCommand());
            commandList.Add(_dataCommandConverter.Convert(mailMessage));
            return commandList;
        }
    }
}
