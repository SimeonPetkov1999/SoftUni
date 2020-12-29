using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var currentName = Console.ReadLine();
                names.Add(currentName);
            }

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
