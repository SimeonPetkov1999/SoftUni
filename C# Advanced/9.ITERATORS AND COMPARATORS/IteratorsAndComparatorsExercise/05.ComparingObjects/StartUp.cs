using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var list = new List<Person>();

            var input = Console.ReadLine()
                .Split();
            while (input[0]!="END")
            {
                list.Add(new Person(input[0], int.Parse(input[1]), input[2]));
                input = Console.ReadLine()
                .Split();
            }

            int n = int.Parse(Console.ReadLine());
            var personToCompare = list[n - 1];


            for (int i = 0; i < list.Count; i++)
            {
                if (i + 1 == n)
                {
                    continue;
                }
                var currentPerson = list[i];
                personToCompare.CompareTo(currentPerson);
            }

            if (personToCompare.CountMatches>1)
            {
                Console.WriteLine($"{personToCompare.CountMatches} {list.Count - personToCompare.CountMatches} {list.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
           
         }
    }
}
