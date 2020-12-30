using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int n = input[0];
            int m = input[1];

            var hashSetN = new HashSet<int>();
            var hashSetM = new HashSet<int>();
            var hashSetUniques = new HashSet<int>();


            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                hashSetN.Add(num);
            }
            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                hashSetM.Add(num);
                if (hashSetN.Contains(num))
                {
                    hashSetUniques.Add(num);
                }
            }

            foreach (var item in hashSetN)
            {
                if (hashSetUniques.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }

            //Console.WriteLine(string.Join(" ",hashSetN.Intersect(hashSetM)));
            
            

        }
    }
}
