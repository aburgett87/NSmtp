using System;
using System.Collections.Generic;
using NSmtp.Enums;

namespace NSmtp.Parsers
{
    public interface ISuccessfulCommandToResponseFactory
    {
        List<SmtpResponseCode> CreateResponseList(string command);
    }
}
