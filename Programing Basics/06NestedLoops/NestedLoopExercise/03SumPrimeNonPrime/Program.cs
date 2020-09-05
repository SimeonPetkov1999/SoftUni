using System;

namespace _03SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            int sumPrimeNumbers = 0;
            int sumNonPrimeNumbers = 0;

            while (input!="stop")
            {
                int num = int.Parse(input);
                if (num<0)
                {
                    Console.WriteLine("Number is negative.");
                    input = Console.ReadLine();
                    continue;
                }

                int a = 0;
                for (int i = 1; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        a++;
                    }
                }
                if (a == 2)
                {
                    sumPrimeNumbers += num;
                }
                else
                {
                    sumNonPrimeNumbers += num;
                }            

                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNumbers}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNumbers}");

        }
    }
}
