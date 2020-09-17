using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num = int.Parse(input);
            int finalSum = 0;
            int digitFactorial = 1;

            for (int i = 0; i < input.Length; i++)
            {
                int currentDigit = int.Parse(input[i].ToString());
                for (int j = 1; j <= currentDigit; j++)
                {
                    digitFactorial *= j;
                }
                finalSum += digitFactorial;
                digitFactorial = 1;
            }

            if (finalSum == num)
            {
                Console.WriteLine("yes");
            }

            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
