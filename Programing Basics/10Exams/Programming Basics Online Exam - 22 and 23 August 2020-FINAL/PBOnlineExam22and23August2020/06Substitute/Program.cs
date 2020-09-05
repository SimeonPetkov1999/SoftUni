using System;

namespace _06Substitute
{
    class Program
    {
        static void Main(string[] args)
        {
            int K = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            int combinations = 0;

            for (int firstOne = K; firstOne <= 8; firstOne++)
            {
                for (int secondOne = 9; secondOne >= L; secondOne--)
                {
                    for (int firstTwo = M; firstTwo <= 8; firstTwo++)
                    {
                        for (int secondTwo = 9; secondTwo >= N; secondTwo--)
                        {
                            bool firstCondition = firstOne % 2 == 0 && firstTwo % 2 == 0;
                            bool secondCondition = secondOne % 2 != 0 && secondTwo % 2 != 0;
                            bool equalNumbers = firstOne == firstTwo && secondOne == secondTwo;

                            if (firstCondition && secondCondition)
                            {
                                if (equalNumbers)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                    continue;
                                }
                                Console.WriteLine($"{firstOne}{secondOne} - {firstTwo}{secondTwo}");
                                combinations++;

                                if (combinations == 6)
                                {
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
