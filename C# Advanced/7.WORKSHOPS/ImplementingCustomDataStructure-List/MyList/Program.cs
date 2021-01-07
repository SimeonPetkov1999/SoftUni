using System;
using System.Collections.Generic;
using System.Linq;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList<int>{ 111,222,333,444};

            for (int i = 1; i < 100; i++)
            {
                list.Add(i);
            }

            Console.WriteLine(string.Join(", ", list));
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
