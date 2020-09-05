using System;

namespace _05SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string input;
            double suitcaseVolume;
            int suitcaseNum = 1;
            int statistic = 0;

            while (true)
            {
                input = Console.ReadLine().ToLower();
                if (input!="end")
                {
                    suitcaseVolume = double.Parse(input);

                    if (suitcaseVolume >= capacity)
                    {
                        Console.WriteLine("No more space!");
                        Console.WriteLine($"Statistic: {statistic} suitcases loaded.");
                        break;
                    }

                    if (suitcaseNum % 3 == 0)
                    {
                        capacity = capacity - ((suitcaseVolume * 0.1) + suitcaseVolume);
                        

                        if (capacity<0)
                        {
                            Console.WriteLine("No more space!");
                            Console.WriteLine($"Statistic: {statistic} suitcases loaded.");
                            break;
                        }

                        statistic++;

                    }

                    else
                    {
  
                        capacity = capacity - suitcaseVolume;
                        statistic++;
                    }
                }

                else
                {
                    Console.WriteLine("Congratulations! All suitcases are loaded!");
                    Console.WriteLine($"Statistic: {statistic} suitcases loaded.");
                    break;
                }

                suitcaseNum++;
            }

        }
    }
}
