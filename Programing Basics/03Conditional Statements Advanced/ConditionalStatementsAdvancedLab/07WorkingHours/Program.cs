using System;

namespace _07WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeOfDay = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                case "Saturday":
                    if (timeOfDay>=10 && timeOfDay<=18)
                    {
                        Console.WriteLine("open");
                    }
                    else
                    {
                        Console.WriteLine("closed");
                    }
                    break;
                default:
                    Console.WriteLine("closed");
                    break;
            }
        }
    }
}
