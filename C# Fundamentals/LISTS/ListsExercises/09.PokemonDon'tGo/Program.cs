using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();

            int sumOfRemoved = 0;

            while (numbers.Count!=0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index<0)
                {
                    int copyEnd = numbers[numbers.Count - 1];
                    int removed = numbers[0];
                    sumOfRemoved += numbers[0];
                    numbers.RemoveAt(0);
                    numbers.Insert(0, copyEnd);
                    IncreaseDecrease(numbers, removed);                    
                }

                else if (index>numbers.Count-1)
                {
                    int copyFirst = numbers[0];
                    int removed = numbers[numbers.Count - 1];
                    sumOfRemoved += numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Add(copyFirst);
                    IncreaseDecrease(numbers, removed);
                }

                else
                {
                    int removed = numbers[index];
                    sumOfRemoved += removed;
                    numbers.RemoveAt(index);
                    IncreaseDecrease(numbers, removed);
                }
            }
            Console.WriteLine(sumOfRemoved);
         }

        static void IncreaseDecrease(List<int> numbers, int removed) 
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= removed)
                {
                    numbers[i] += removed;
                }
                else
                {
                    numbers[i] -= removed;
                }
            }
        }
    }
}
