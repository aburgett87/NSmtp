using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class BoundaryDataField : IDataField
    {
        string _boundary;

        public BoundaryDataField(string boundary)
        {
            _boundary = boundary;
        }

        public string Heading
        {
            get { return String.Empty; }
        }

        public string Content
        {
            get { return "--" + _boundary; }
        }
    }
}
