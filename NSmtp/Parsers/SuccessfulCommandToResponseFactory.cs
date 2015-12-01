using System;
using System.Collections.Generic;
using NSmtp.Enums;

namespace NSmtp.Parsers
{
    public class SuccessfulCommandToResponseFactory : ISuccessfulCommandToResponseFactory
    {
        public List<SmtpResponseCode> CreateResponseList(string command)
        {
            switch (command)
            {
                case SmtpCommands.Data:
                    return new List<SmtpResponseCode> { SmtpResponseCode.StartMailInputEndWithDot };
                case SmtpCommands.Quit:
                    return new List<SmtpResponseCode> { SmtpResponseCode.ClosingTransmissionChannel };
                case SmtpCommands.Auth:
                    return new List<SmtpResponseCode>
                    {
                        SmtpResponseCode.AuthenticationContinue,
                        SmtpResponseCode.AuthenticationOK
                    };
                default:
                    return new List<SmtpResponseCode> 
                    {
                        SmtpResponseCode.OK,
                        SmtpResponseCode.AuthenticationOK,
                        SmtpResponseCode.AuthenticationContinue
                    };
            }
        }
    }
}
