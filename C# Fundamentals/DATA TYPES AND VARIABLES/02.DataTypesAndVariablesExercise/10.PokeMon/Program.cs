using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            int firstValueN = N;
            int pokes = 0;


            while (N >= M)
            {
                if (firstValueN / 2 == N && Y != 0)
                {
                    N = N / Y;
                    if (N < M)
                    {
                        break;
                    }
                }
                N = N - M;
                pokes++;
            }
            Console.WriteLine(N);
            Console.WriteLine(pokes);
        }
    }
}
