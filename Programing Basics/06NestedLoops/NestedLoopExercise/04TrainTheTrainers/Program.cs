using System;

namespace _04TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            double currMark = 0;
            double markForPresentation = 0;
            double averageMark = 0;
            double finalAverageMark = 0;
            int numberOfMarks = 0;

            string nameOfPresentation = Console.ReadLine();

            while (nameOfPresentation!="Finish")
            {
                numberOfMarks++;
                for (int i = 0; i < numberOfPeople; i++)
                {
                    currMark = double.Parse(Console.ReadLine());
                    markForPresentation += currMark;
                }

                averageMark = markForPresentation / numberOfPeople;
                finalAverageMark += averageMark;
               
                Console.WriteLine($"{nameOfPresentation} - {averageMark:f2}.");
                averageMark = 0;
                markForPresentation = 0;


                nameOfPresentation = Console.ReadLine();
            }

            double output = finalAverageMark / numberOfMarks;
            Console.WriteLine($"Student's final assessment is {output:f2}.");
        }
    }
}
