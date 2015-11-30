using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp
{
    internal static class DataFieldHeadings
    {
        internal const string From = "FROM: ";

        internal const string To = "TO: ";

        internal const string Cc = "CC: ";

        internal const string Bcc = "BCC: ";

        internal const string ReplyTo = "REPLY-TO: ";

        internal const string Subject = "SUBJECT: ";

        internal const string Date = "DATE: ";

        internal const string MimeVersion = "MIME-Version: ";

        internal const string ContentType = "Content-type: ";

        internal const string AttatchmentBoundary = "attachment-boundary";

        internal const string TextBoundary = "text-boundary";
    }
}
