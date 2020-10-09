using System;

namespace _04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Tribonacci(num);
        }
        static void Tribonacci(int num) 
        {
            int[] sequence = {1,1,2,4};
            for (int i = 4; i < num; i++)
            {
                int[] temp = new int[sequence.Length + 1];
                for (int j = 0; j < sequence.Length; j++)
                {
                    temp[j] = sequence[j];
                }
                temp[i] = sequence[i-3] + sequence[i-2] + sequence[i-1];
                sequence = temp;           
            }
            for (int i = 0; i < num; i++)
            {
                Console.Write(sequence[i] + " ");
            }        
        }
    }
}
