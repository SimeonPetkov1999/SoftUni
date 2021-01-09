using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Pet
    {
        private string name;
        private int age;
        private string owner;

        public string Name 
        {
            get { return this.name; }
            set { this.name = value; } 
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public Pet(string name, int age,string owner)
        {
            this.name = name;
            this.age = age;
            this.owner = owner;
        }

        public override string ToString()
        {
            return $"Name: {this.Name} Age: {this.Age} Owner: {this.Owner}"; 
        }
    }
}
