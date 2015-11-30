using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class FromDataField : IDataField
    {
        public FromDataField(string text)
        {
            Content = text;
        }

        public string Heading
        {
            get { return DataFieldHeadings.From; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
