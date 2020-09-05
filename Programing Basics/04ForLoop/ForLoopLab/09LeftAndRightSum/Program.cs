using System;

namespace _09LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 0;
            int leftSum = 0;
            int rightSum = 0;

            //for (int i = 0; i < n; i++)
            //{
            //    num = int.Parse(Console.ReadLine());
            //    leftSum += num;
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    num = int.Parse(Console.ReadLine());
            //    rightSum += num;
            //}

            for (int i = 0; i < n*2; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (i<n)
                {
                    leftSum += num;
                }

                else
                {
                    rightSum += num;
                }
            }

            if (leftSum==rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }

            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum-rightSum)}");
            }
        }
    }
}
