using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bombNum = bomb[0];
            int power = bomb[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNum)
                {                                   
                    if (i+power>numbers.Count-1)
                    {
                        numbers.RemoveRange(i+1,(i + power)-numbers.Count);
                    }
                    else
                    {
                        numbers.RemoveRange(i+1, power);
                    }

                    if (i-power<0)
                    {
                        numbers.RemoveRange(0, power-(Math.Abs(i-power)));
                    }
                    else
                    {
                        numbers.RemoveRange(i - power, power);
                    }                  
                    numbers.Remove(bombNum);

                    i = 0;
                }

            }

            Console.WriteLine(numbers.Sum());
         }
    }
}
