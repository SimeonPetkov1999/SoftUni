using _05.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations.Models
{
    class Cititzen : IID , IBirthable
    {
        public Cititzen(string name,int age,string id,string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.BirthDate = birthDate;
        }
        public string Name { get; private set; }
        public int Age { get; set; }
        public string ID {get; private set; }
        public string BirthDate { get; private set; }
        public string BirthYear => this.BirthDate.Substring(this.BirthDate.Length - 4);
    }
}
