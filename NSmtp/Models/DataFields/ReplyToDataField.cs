using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class ReplyToDataField : IDataField
    {
        public ReplyToDataField(string text)
        {
            Content = text;
        }

        public string Heading
        {
            get { return DataFieldHeadings.ReplyTo; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
