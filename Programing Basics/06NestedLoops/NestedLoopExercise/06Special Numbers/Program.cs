using System;

namespace _06Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                int check = i;
                int num4 = check % 10;
                check = check / 10;
                int num3 = check % 10;
                check = check / 10;
                int num2 = check % 10;
                check = check / 10;
                int num1 = check % 10;

                if (num1 == 0 || num2 == 0 || num3 == 0 || num4 == 0)
                {
                    continue;
                }
                if (num % num1 == 0 && num % num2 == 0 && num % num3 == 0 && num % num4 == 0)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
