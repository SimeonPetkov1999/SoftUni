using System;

namespace _11.MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputA = int.Parse(Console.ReadLine());
            int inputB = int.Parse(Console.ReadLine());

            if (inputB>10)
            {
                int result = inputA * inputB;
                Console.WriteLine($"{inputA} X {inputB} = {result}");
            }

            for (int i = inputB; inputB <= 10; inputB++)
            {
                int result = inputA * inputB;
                Console.WriteLine($"{inputA} X {inputB} = {result}");
            }
        }
    }
}
