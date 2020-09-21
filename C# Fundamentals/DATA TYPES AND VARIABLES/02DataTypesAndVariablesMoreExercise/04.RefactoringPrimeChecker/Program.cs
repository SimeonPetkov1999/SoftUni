using System;

namespace _04.RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int finalNum = int.Parse(Console.ReadLine());
            for (int num = 2; num <= finalNum; num++)
            {
                bool IsPrime = true;
                for (int n = 2; n < num; n++)
                {
                    if (num % n == 0)
                    {
                        IsPrime = false;
                        break;
                    }
                }
                string outuput = string.Empty;
                if (IsPrime)
                {
                   outuput = "true";
                }
                else
                {
                   outuput = "false";
                }
                Console.WriteLine("{0} -> {1}", num, outuput);
            }

        }
    }
}
