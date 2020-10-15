using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string text = Console.ReadLine();
            string resultText = string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                int textLenght = text.Length;
                int curentNum = numbers[i];
                int sum = 0;
                while (curentNum != 0)
                {
                    sum += curentNum % 10;
                    curentNum = curentNum / 10;
                }

                if (sum > textLenght)
                {
                    sum -= textLenght;
                }

                resultText += text[sum];
                text = text.Remove(sum, 1);
            }

            Console.WriteLine(resultText);
        }
    }
}
