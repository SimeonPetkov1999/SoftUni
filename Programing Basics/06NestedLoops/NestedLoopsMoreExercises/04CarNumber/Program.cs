using System;

namespace _04CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int firstNum = start; firstNum <= end; firstNum++)
            {
                for (int secondNum = start; secondNum <= end; secondNum++)
                {
                    for (int thirdNum = start; thirdNum <= end; thirdNum++)
                    {
                        for (int fourtNum = start; fourtNum <= end; fourtNum++)
                        {
                            bool firstCondition = (firstNum % 2 == 0 && fourtNum % 2 != 0) || (firstNum % 2 != 0 && fourtNum % 2 == 0);
                            bool secondCondition = firstNum > fourtNum;
                            bool thirdCondition = (secondNum + thirdNum) % 2 == 0;
                            if (firstCondition && secondCondition && thirdCondition)
                            {
                                Console.Write($"{firstNum}{secondNum}{thirdNum}{fourtNum} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
