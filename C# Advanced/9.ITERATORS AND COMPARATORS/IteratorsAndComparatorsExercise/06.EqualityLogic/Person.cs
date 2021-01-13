using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06.EqualityLogic
{
    class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
                if (result == 0)
                {
                    return result;
                }
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this.Name == person.Name && this.Age == person.Age;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
