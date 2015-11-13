using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp
{
    internal static class SmtpCommands
    {
        internal static readonly string Auth = "AUTH ";

        internal static readonly string CRLF = "\r\n";

        internal static readonly string Data = "DATA\r\n";

        internal static readonly string DataStop = "\r\n.\r\n";

        internal static readonly string EHello = "EHLO ";

        internal static readonly string Expand = "EXPN ";

        internal static readonly string Hello = "HELO ";

        internal static readonly string Help = "HELP";

        internal static readonly string MailFrom = "MAIL FROM:";

        internal static readonly string Noop = "NOOP\r\n";

        internal static readonly string Quit = "QUIT\r\n";

        internal static readonly string Recipient = "RCPT TO:";

        internal static readonly string Reset = "RSET\r\n";

        internal static readonly string Send = "SEND FROM:";

        internal static readonly string SendAndMail = "SAML FROM:";

        internal static readonly string SendOrMail = "SOML FROM:";

        internal static readonly string Turn = "TURN\r\n";

        internal static readonly string Verify = "VRFY ";

        internal static readonly string StartTls = "STARTTLS";
    }
}
