using _04.BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    class Cititzen : IInhabitant
    {
        public Cititzen(string name,int age,string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }
        public string Name { get; private set; }
        public int Age { get; set; }
        public string ID {get; private set; }
    }
}
