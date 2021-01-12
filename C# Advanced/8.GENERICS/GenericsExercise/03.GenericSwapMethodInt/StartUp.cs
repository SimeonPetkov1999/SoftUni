using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            var indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var firstIndex = indexes[0];
            var secondIndex = indexes[1];

            Swap(list, firstIndex, secondIndex);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        static void Swap<T>(List<T> list, int index1, int index2) 
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
