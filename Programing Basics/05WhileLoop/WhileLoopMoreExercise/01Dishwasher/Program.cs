using System;

namespace _01Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBottlesWithDetergent = int.Parse(Console.ReadLine());
            double AllLiters = numberOfBottlesWithDetergent * 750;

            int numberOfDishesh = 0;
            int numberOfPots = 0;
            int loadNum = 0;
            int load;

            string input = Console.ReadLine();
            while (input != "End")
            {
                loadNum++;
                load = int.Parse(input);

                if (loadNum % 3 != 0)
                {
                    numberOfDishesh += load;
                    AllLiters = AllLiters - (load * 5);
                }
                else
                {
                    numberOfPots += load;
                    AllLiters = AllLiters - (load * 15);
                }

                if (AllLiters<0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(AllLiters)} ml. more necessary!");
                    Environment.Exit(0);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Detergent was enough!");
            Console.WriteLine($"{numberOfDishesh} dishes and {numberOfPots} pots were washed.");
            Console.WriteLine($"Leftover detergent {AllLiters} ml.");


        }
    }
}
