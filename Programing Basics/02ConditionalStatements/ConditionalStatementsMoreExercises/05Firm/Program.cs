using System;

namespace _05Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int availableDays = int.Parse(Console.ReadLine());
            int workersWorkingOverTime = int.Parse(Console.ReadLine());

            double workHours = (availableDays * 0.9) * 8;
            double overtimeHours = workersWorkingOverTime * (2 * availableDays);
            double totalHours = Math.Floor(workHours + overtimeHours);

            if (totalHours>=neededHours)
            {
                Console.WriteLine($"Yes!{totalHours - neededHours} hours left.");
            }

            else
            {
                Console.WriteLine($"Not enough time!{neededHours - totalHours} hours needed.");
            }

        }
    }
}
