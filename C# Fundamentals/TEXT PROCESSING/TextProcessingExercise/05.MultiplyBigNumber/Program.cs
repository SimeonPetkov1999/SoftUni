using System;
using System.Collections.Generic;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = input.TrimStart(new char[] { '0' });
            char[] bigNum = input.ToCharArray();
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine("0");
                Environment.Exit(0);
            }
            List<string> newNum = new List<string>();

            int currentNUm = 0;
            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                currentNUm = (int.Parse(Convert.ToString(bigNum[i])) * number) + currentNUm;
                newNum.Insert(0, (currentNUm % 10).ToString());
                currentNUm /= 10;
            }
            if (currentNUm > 0)
            {
                Console.WriteLine($"{currentNUm}{string.Join("", newNum)}");
            }
            else
            {
                Console.WriteLine($"{string.Join("", newNum)}");
            }
        }
    }
}
