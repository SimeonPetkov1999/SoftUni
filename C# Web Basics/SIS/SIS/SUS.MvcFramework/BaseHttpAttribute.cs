using SUS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public abstract class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }

        public abstract HttpMethod Method { get; }
    }
}
