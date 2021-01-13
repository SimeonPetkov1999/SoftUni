using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo(Person other)
        {

            var result = other.Name.CompareTo(this.Name);
            if (result == 0)
            {
                result = other.Age.CompareTo(this.Age);
                if (result == 0)
                {
                    result = other.Town.CompareTo(this.Town);
                    if (result == 0)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
