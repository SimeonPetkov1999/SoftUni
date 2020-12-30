using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var hashSet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                hashSet.Add(Console.ReadLine());
            }

            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
