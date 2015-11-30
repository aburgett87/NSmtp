using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class ContentTypeDataField : IDataField
    {
        public ContentTypeDataField(string content)
        {
            Content = content;
        }

        public string Heading
        {
            get { return DataFieldHeadings.ContentType; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
