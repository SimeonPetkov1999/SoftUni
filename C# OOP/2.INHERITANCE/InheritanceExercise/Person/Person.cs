using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;
        private string name;

        public Person(string name,int age)
        {
            this.Age = age;
            this.Name = name;
        }
        public int Age 
        {
            get { return this.age; }
            private set
            {
                if (value>=0)
                {
                    this.age = value;
                }
                else
                {
                    throw new InvalidOperationException("Age can't be negative number");
                }
            } 
        }
        public string Name 
        {
            get { return this.name; }
            private set { this.name = value; } 
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Name: {this.Name}, Age: {this.Age}");
            return sb.ToString();
        }
    }
}
