using System;
using NSmtp.Models;
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
                default:
                    throw new ArgumentOutOfRangeException("Reponse code invalid");
            }
        }
    }
}
