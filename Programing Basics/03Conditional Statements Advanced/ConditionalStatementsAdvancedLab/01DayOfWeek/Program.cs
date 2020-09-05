using System;

namespace _01DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            string nameOfDay;

            switch (day)
            {
                case 1:
                    nameOfDay = "Monday";
                    break;
                case 2:
                    nameOfDay = "Tuesday";
                    break;
                case 3:
                    nameOfDay = "Wednesday";
                    break;
                case 4:
                    nameOfDay = "Thursday";
                    break;
                case 5:
                    nameOfDay = "Friday";
                    break;
                case 6:
                    nameOfDay = "Saturday";
                    break;
                case 7:
                    nameOfDay = "Sunday";
                    break;
                default:
                    nameOfDay = "Error";
                    break;
            }

            Console.WriteLine(nameOfDay);

        }
    }
}
