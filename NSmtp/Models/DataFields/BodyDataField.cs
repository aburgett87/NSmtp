using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class BodyDataField : IDataField
    {
        public BodyDataField(string text)
        {
            Content = text;
        }

        public string Heading
        {
            get { return String.Empty; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
