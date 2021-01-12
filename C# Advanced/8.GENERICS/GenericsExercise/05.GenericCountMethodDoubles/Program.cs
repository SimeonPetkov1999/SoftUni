using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            var item = Console.ReadLine();
            Console.WriteLine(Count(list,item));
        }

        static int Count<T>(List<T> list, string compare) where T:IComparable
        {
            return list
                .Where(x => x.CompareTo(compare) > 0)
                .Count();
        }
    }
}
