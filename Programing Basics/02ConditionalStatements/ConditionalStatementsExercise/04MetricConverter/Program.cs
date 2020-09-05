using System;

namespace _04MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            string inputMeters = Console.ReadLine();
            string outputMeters = Console.ReadLine();

            double outputCM = 0.0;
            double outputMM = 0.0;
            double outputM = 0.0;

            if (inputMeters == "m")
            {
                outputCM = input * 100;
                outputMM = input * 1000;

                if (outputMeters =="cm")
                {
                    Console.WriteLine($"{outputCM:f3}");
                }
                else
                {
                    Console.WriteLine($"{outputMM:f3}");
                }
            }

            else if (inputMeters == "cm")
            {
                outputM = input / 100;
                outputMM = input * 10;

                if (outputMeters == "m")
                {
                    Console.WriteLine($"{outputM:f3}");
                }
                else
                {
                    Console.WriteLine($"{outputMM:f3}");
                }
            }

            else 
            {
                outputM = input / 1000;
                outputCM = input / 10;

                if (outputMeters == "m")
                {
                    Console.WriteLine($"{outputM:f3}");
                }
                else
                {
                    Console.WriteLine($"{outputCM:f3}");
                }
            }

        }
    }
}
