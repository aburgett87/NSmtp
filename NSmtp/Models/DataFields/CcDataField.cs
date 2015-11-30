using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class CcDataField : IDataField
    {
        public CcDataField(string text)
        {
            Content = text;
        }

        public string Heading
        {
            get { return DataFieldHeadings.Cc; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
