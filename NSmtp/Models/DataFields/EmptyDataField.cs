﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSmtp.Models.DataFields
{
    public class EmptyDataField : IDataField
    {
        public string Heading
        {
            get { return String.Empty; }
        }

        public string Content
        {
            get { return String.Empty; }
        }
    }
}
