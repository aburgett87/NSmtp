using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class MessageIdDataField : IDataField
    {
        public MessageIdDataField(string messageId)
        {
            Content = messageId;
        }

        public string Heading
        {
            get { return "Message-Id: "; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
