using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp
{
    internal static class SmtpCommands
    {
        internal const string Auth = "AUTH";

        internal const string Data = "DATA";

        internal const string DataStop = ".";

        internal const string EHello = "EHLO";

        internal const string Expand = "EXPN";

        internal const string Hello = "HELO";

        internal const string Help = "HELP";

        internal const string MailFrom = "MAIL FROM:";

        internal const string Noop = "NOOP";

        internal const string Quit = "QUIT";

        internal const string Recipient = "RCPT TO:";

        internal const string Reset = "RSET";

        internal const string Send = "SEND FROM:";

        internal const string SendAndMail = "SAML FROM:";

        internal const string SendOrMail = "SOML FROM:";

        internal const string Turn = "TURN";

        internal const string Verify = "VRFY ";

        internal const string StartTls = "STARTTLS";

        internal const string From = "FROM: ";

        internal const string To = "TO: ";

        internal const string Cc = "CC: ";

        internal const string Bcc = "BCC: ";

        internal const string ReplyTo = "REPLY-TO: ";

        internal const string Subject = "SUBJECT: ";

        internal const string Date = "DATE: ";

        internal const string Empty = "";
    }
}
