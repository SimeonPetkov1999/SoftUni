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
            int matches = 0;
            var personToCompare = list[n - 1];


            foreach (var currentPerson in list)
            {
                if (personToCompare.CompareTo(currentPerson) == 0)
                {
                    matches++;
                }
              
            }

            if (matches>1)
            {
                Console.WriteLine($"{matches} {list.Count - matches} {list.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
           
         }
    }
}
