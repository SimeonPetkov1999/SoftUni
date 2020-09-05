using System;

namespace _06OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            char character = char.Parse(Console.ReadLine());

            double result;
            if (character=='+')
            {
                result = N1 + N2;
                bool isEven = result % 2 == 0;
                if (isEven)
                {
                    Console.WriteLine($"{N1} {character} {N2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {character} {N2} = {result} - odd");
                }
            }

            else if (character=='-')
            {
                result = N1 - N2;
                bool isEven = result % 2 == 0;
                if (isEven)
                {
                    Console.WriteLine($"{N1} {character} {N2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {character} {N2} = {result} - odd");
                }
            }

            else if (character == '*')
            {
                result = N1 * N2;
                bool isEven = result % 2 == 0;
                if (isEven)
                {
                    Console.WriteLine($"{N1} {character} {N2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {character} {N2} = {result} - odd");
                }
            }

            else if (character == '/')
            {
               
               
                if (N2==0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }

                else
                {
                    
                    result = (N1*1.0) / N2;
                    Console.WriteLine($"{N1} / {N2} = {result:f2}");
                }
            }

            else
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }

                else
                {
                    result = N1 % N2;
                    Console.WriteLine($"{N1} % {N2} = {result}");
                }
               
              
            }


        }
    }
}
