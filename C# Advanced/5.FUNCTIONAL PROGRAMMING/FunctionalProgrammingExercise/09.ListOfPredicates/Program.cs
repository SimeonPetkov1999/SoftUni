using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        public static void Main()
        {
            Func<int, int, bool> divide = (n, d) => n % d == 0;

            int n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var result = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                bool flag = true;

                for (int j = 0; j < numbers.Count; j++)
                {
                    if (!divide(i, numbers[j]))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
