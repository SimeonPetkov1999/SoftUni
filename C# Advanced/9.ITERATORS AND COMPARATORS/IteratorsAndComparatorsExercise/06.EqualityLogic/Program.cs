using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];
                var age = int.Parse(input[1]);

                var currentPerson = new Person(name, age);
                sortedSet.Add(currentPerson);
                hashSet.Add(currentPerson);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
