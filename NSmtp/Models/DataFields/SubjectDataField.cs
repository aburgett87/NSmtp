using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class SubjectDataField : IDataField
    {
        public SubjectDataField(string text)
        {
            Content = text;
        }

        public string Heading
        {
            get { return DataFieldHeadings.Subject; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
