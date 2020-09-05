using System;

namespace _08OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hExam = int.Parse(Console.ReadLine());
            int mExam = int.Parse(Console.ReadLine());
            int hArrived = int.Parse(Console.ReadLine());
            int mArrived = int.Parse(Console.ReadLine());

            int minutesExam = mExam + (hExam * 60);
            int minutesArrived = mArrived + (hArrived * 60);
            int difference = minutesExam - minutesArrived;

            if (difference == 0)
            {
                Console.WriteLine("On time");
            }

            else if (difference > 0 && difference <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{difference} minutes before the start");
            }

            else if (difference>30)
            {
                Console.WriteLine("Early");
                if (difference>59)
                {
                    int hours = difference / 60;
                    int minutes = difference % 60;
                    Console.WriteLine($"{hours}:{minutes:d2} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{difference} minutes before the start  ");
                }
            }


            else if (difference<0)
            {
                difference = Math.Abs(difference);

                Console.WriteLine("Late");
                if (difference>59)
                {
                    int hours = difference / 60;
                    int minutes = difference % 60;
                    Console.WriteLine($"{hours}:{minutes:d2} hours after the start");
                }

                else
                {
                    Console.WriteLine($"{difference} minutes after the start  ");
                }
            }

        }
    }
}
