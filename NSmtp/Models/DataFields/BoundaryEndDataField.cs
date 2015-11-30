using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class BoundaryEndDataField : IDataField
    {
        private readonly string _boundary;

        public BoundaryEndDataField(string boundary)
        {
            _boundary = boundary;
        }

        public string Heading
        {
            get { return String.Empty; }
        }

        public string Content
        {
            get { return "--" + _boundary + "--"; }
        }
    }
}
