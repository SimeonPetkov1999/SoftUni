using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Person> persons = new List<Person>();
            while (input[0]!="End")
            {
                Person currentPerson = new Person(input[0],input[1],int.Parse(input[2]));
                persons.Add(currentPerson);
                input = Console.ReadLine().Split();
            }

            persons = persons.OrderBy(n => n.Age).ToList();

            foreach (var person in persons)
            {
                person.PrintPerson();
            }
        }
        class Person
        {
            public Person(string name, string id, int age)
            {
                this.Name = name;
                this.ID = id;
                this.Age = age;
            }
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }
            public void PrintPerson()
            {
                Console.WriteLine($"{Name} with ID: {ID} is {Age} years old.");
            }
        }
    }
}
