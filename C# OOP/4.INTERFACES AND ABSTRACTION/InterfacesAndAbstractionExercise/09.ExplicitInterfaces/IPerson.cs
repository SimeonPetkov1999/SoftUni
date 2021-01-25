using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    interface IPerson
    {
        public string Name { get; }
        public int Age { get; }
        public string GetName();
    }
}
