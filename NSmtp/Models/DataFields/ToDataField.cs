using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class ToDataField : IDataField
    {
        public ToDataField(string text)
        {
            Content = text;
        }

        public string Heading
        {
            get { return DataFieldHeadings.To; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
