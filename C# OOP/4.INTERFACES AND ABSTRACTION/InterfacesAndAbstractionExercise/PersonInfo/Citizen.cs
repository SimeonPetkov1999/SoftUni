using System;
using System.Text;
using System.Collections.Generic;

namespace PersonInfo
{
    class Citizen : IPerson
    {
        public string Name { get;private set; }
        public int Age { get; private set; }

        public Citizen(string name,int age)
        {
            this.Age = age;
            this.Name = name;
        }
    }
}
