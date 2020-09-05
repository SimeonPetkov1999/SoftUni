using System;

namespace _13PrimePairs
{
    class Program
    {

       static bool isPrime(int a)
       {
           bool check = false;
           int M = 0;
           for (int i = 1; i <= a; i++)
           {
               if (a % i == 0)
               {
                   M++;
               }
           }
           if (M == 2)
           {
               check = true;
           }
           return check;
       }

        static void Main(string[] args)
        {         
            int startOfFirstDouble = int.Parse(Console.ReadLine());
            int startOfSecondDouble = int.Parse(Console.ReadLine());
            int endOfFirstDouble = int.Parse(Console.ReadLine());
            int endOfSecondDouble = int.Parse(Console.ReadLine());
            endOfFirstDouble += startOfFirstDouble;
            endOfSecondDouble += startOfSecondDouble;

            for (int firstDouble = startOfFirstDouble; firstDouble <= endOfFirstDouble; firstDouble++)
            {            
                for (int secondDouble = startOfSecondDouble; secondDouble <= endOfSecondDouble; secondDouble++)
                {
                    if (isPrime(firstDouble) && isPrime(secondDouble))
                    {
                        Console.WriteLine($"{firstDouble}{secondDouble}");
                    }              
                }
            }


        }
    }
}
   


