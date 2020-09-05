using System;

namespace _02EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());


            for (int i = firstNum; i <= secondNum; i++)
            {
                string currentNum = i.ToString();
                int oddPosition = 0;
                int evenPosition = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int currentDigit = int.Parse(currentNum[j].ToString());

                    if (j % 2 == 0)
                    {
                        evenPosition +=currentDigit;
                    }

                    else
                    {
                        oddPosition +=currentDigit;
                    }
                }

                if (evenPosition == oddPosition)
                {
                    Console.Write(i + " ");
                }

               

            }
        }
    }
}
