﻿using System;

namespace _03Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int combinations = 0;

            for (int x1 = 0; x1 <= n; x1++)
            {
                for (int x2 = 0; x2 <= n; x2++)
                {
                    for (int x3 = 0; x3 <=n; x3++)
                    {
                        int result = x1 + x2 + x3;
                        if (result==n)
                        {
                            combinations++;
                        }
                    }
                }
            }

            Console.WriteLine(combinations);
        }
    }
}
