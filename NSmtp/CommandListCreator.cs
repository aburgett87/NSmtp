using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using NSmtp.Models;
using NSmtp.Converters;
using NSmtp.Models.Commands;
using NSmtp.Enums;

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

            if (!(String.IsNullOrWhiteSpace(_hostInfo.Username) || String.IsNullOrWhiteSpace(_hostInfo.Password)))
            {
                commandList.Add(new EHelloCommand(_hostInfo.Host));
                commandList.Add(new AuthCommand(_hostInfo.AuthType.ToString("G").ToUpper()));
                if (_hostInfo.AuthType == AuthType.Login)
                {
                    commandList.Add(new UsernameCommand(Convert.ToBase64String(Encoding.Default.GetBytes(_hostInfo.Username))));
                    commandList.Add(new PasswordCommand(Convert.ToBase64String(Encoding.Default.GetBytes(_hostInfo.Password))));
                }
                else
                {
                    commandList.Add(new PasswordCommand(Convert.ToBase64String(Encoding.Default.GetBytes( "\0" + _hostInfo.Username + "\0" + _hostInfo.Password))));
                }
            }
            else
            {
                commandList.Add(new HelloCommand(_hostInfo.Host));
            }
            commandList.Add(new MailFromCommand("<" + mailMessage.From.Address + ">"));
            commandList.AddRange(_recipientConverter.Convert(mailMessage));
            commandList.Add(new DataCommand());
            commandList.Add(_dataCommandConverter.Convert(mailMessage));
            return commandList;
        }
    }
}
