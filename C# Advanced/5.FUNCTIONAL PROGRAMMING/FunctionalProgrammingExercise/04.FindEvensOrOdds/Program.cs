using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> even = n => n % 2 == 0;
            Predicate<int> odd = n => n % 2 != 0;

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n1 = input[0];
            int n2 = input[1];
            var listOfnumbers = InsertInList(n1, n2);

            var command = Console.ReadLine();

            if (command=="even")
            {
                Console.WriteLine(string.Join(" ",listOfnumbers.FindAll(even)));
            }
            else if (command=="odd")
            {
                Console.WriteLine(string.Join(" ", listOfnumbers.FindAll(odd)));
            }         
        }
        public static List<int> InsertInList(int n1, int n2)
        {
            var list = new List<int>();
            for (int i = n1; i <=n2 ; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
}
