using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public interface IDataField
    {
        string Heading { get; }
        string Content { get; }
    }
}
