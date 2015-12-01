using System;
using NSmtp.Models.Responses;
using NSmtp.Enums;

namespace NSmtp.Parsers
{
    public class ResponseCreator : IResponseCreator
    {
        public IResponse Create(string code, string text)
        {
            var responseCode = (SmtpResponseCode)Convert.ToInt32(code);
            switch (responseCode)
            {
                case SmtpResponseCode.OK:
                    return new OkResponse(text);
                case SmtpResponseCode.ServiceReady:
                    return new ServiceReadyResponse(text);
                case SmtpResponseCode.BadSequenceOfCommands:
                    return new BadSequenceOfCommandsResponse(text);
                case SmtpResponseCode.StartMailInputEndWithDot:
                    return new StartMailInputEndWithDotResponse(text);
                case SmtpResponseCode.ClosingTransmissionChannel:
                    return new ClosingTransmissionChannelResponse(text);
                case SmtpResponseCode.SyntaxErrorCommandUnrecognised:
                    return new SyntaxErrorCommandUnrecognisedResponse(text);
                case SmtpResponseCode.AuthenticationRequired:
                    return new AutheticationRequiredResponse(text);
                case SmtpResponseCode.AuthenticationOK:
                    return new AutheticationOkResponse(text);
                case SmtpResponseCode.AuthenticationContinue:
                    return new AutheticationContinueResponse(text);
                case SmtpResponseCode.AuthenticationFailure:
                    return new AutheticationFailureResponse(text);
                default:
                    throw new ArgumentOutOfRangeException("Reponse code invalid");
            }
        }
    }
}
