using System;

namespace _06MovieTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int one = a1; one <= a2 - 1; one++)
            {
                for (int two = 1; two <= n - 1; two++)
                {
                    for (int three = 1; three <= n / 2 - 1; three++)
                    {
                        bool firstCondition = one % 2 != 0;
                        bool secondCondition = (one + two + three) % 2 != 0;
                        if (firstCondition && secondCondition)
                        {
                            Console.WriteLine($"{(char)one}-{two}{three}{one}");
                        }
                    }
                }
            }

        }
    }
}
