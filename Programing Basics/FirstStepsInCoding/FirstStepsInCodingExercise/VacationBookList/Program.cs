using System;

namespace VacationBookList
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfPages = int.Parse(Console.ReadLine());
            double pagesForHour = double.Parse(Console.ReadLine());
            int Days = int.Parse(Console.ReadLine());

            double Hours = (NumberOfPages / pagesForHour) / Days;

            Console.WriteLine(Hours);
        }
    }
}
