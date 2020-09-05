using System;

namespace _05GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            double from0to9 = 0.0;
            double from10to19 = 0.0;
            double from20to29 = 0.0;
            double from30to39 = 0.0;
            double from40to50 = 0.0;
            double invalid = 0.0;
            double finalResult = 0.0;

            for (int i = 0; i < numbers; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (input >= 0 & input <= 9)
                {
                    finalResult += (input * 0.2);
                    from0to9++;
                }

                else if (input >= 10 && input <= 19)
                {
                    finalResult += (input * 0.3);
                    from10to19++;
                }

                else if (input >= 20 && input <= 29)
                {
                    finalResult += (input * 0.4);
                    from20to29++;
                }

                else if (input >= 30 && input <= 39)
                {
                    finalResult += 50;
                    from30to39++;
                }

                else if (input >= 40 && input <= 50)
                {
                    finalResult += 100;
                    from40to50++;
                }

                else
                {
                    finalResult = finalResult / 2;
                    invalid++;
                }

            }

            from0to9 = (from0to9 / numbers) * 100;
            from10to19 = (from10to19 / numbers) * 100;
            from20to29 = (from20to29 / numbers) * 100;
            from30to39 = (from30to39 / numbers) * 100;
            from40to50 = (from40to50 / numbers) * 100;
            invalid = (invalid / numbers) * 100;

            Console.WriteLine($"{finalResult:f2}");
            Console.WriteLine($"From 0 to 9: {from0to9:f2}%");
            Console.WriteLine($"From 10 to 19: {from10to19:f2}%");
            Console.WriteLine($"From 20 to 29: {from20to29:f2}%");
            Console.WriteLine($"From 30 to 39: {from30to39:f2}%");
            Console.WriteLine($"From 40 to 50: {from40to50:f2}%");
            Console.WriteLine($"Invalid numbers: {invalid:f2}%");



        }
    }
}
