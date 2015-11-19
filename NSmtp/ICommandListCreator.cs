using System;
using System.Collections.Generic;
using NSmtp.Models.Commands;
using System.Net.Mail;

namespace NSmtp
{
    public interface ICommandListCreator
    {
        List<ICommand> Create(MailMessage mailMessage);
    }
}
