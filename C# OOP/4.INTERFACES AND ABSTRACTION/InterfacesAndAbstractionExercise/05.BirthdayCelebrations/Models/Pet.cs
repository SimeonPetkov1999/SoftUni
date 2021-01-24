using _05.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.BirthdayCelebrations.Models
{
    class Pet : IBirthable
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }
        public string Name { get; private set; }
        public string BirthDate { get; private set; }
        public string BirthYear => this.BirthDate.Substring(this.BirthDate.Length - 4);
    }
}
