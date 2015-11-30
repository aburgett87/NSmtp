using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class DateDataField : IDataField
    {
        public DateDataField(string text)
        {
            Content = text;
        }

        public string Heading
        {
            get { return DataFieldHeadings.Date; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
