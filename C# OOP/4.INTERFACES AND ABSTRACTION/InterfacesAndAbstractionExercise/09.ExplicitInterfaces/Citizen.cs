﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    class Citizen : IPerson, IResident
    {

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }
        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        string IPerson.GetName()
        {
            return $"{this.Name}";
        }

        string IResident.GetName() 
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
