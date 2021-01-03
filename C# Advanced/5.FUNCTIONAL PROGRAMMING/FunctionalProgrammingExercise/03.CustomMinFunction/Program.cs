using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> findMin = CreateFunc();


            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(findMin(input));
        }

        public static Func<int[], int> CreateFunc()
        {
            return (array) =>
            {
                int min = int.MaxValue;
                foreach (var item in array)
                {
                    if (min > item)
                    {
                        min = item;
                    }
                }
                return min;
            };
        }
    }
}
