using System;

namespace _08GraduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 0;
            double mark,allMarks=0;
            int failCheck = 0;
            

            while (grade<12)
            {
                if (failCheck==2)
                {
                    Console.WriteLine($"{name} has been excluded at {grade-1} grade");
                    break;
                }

                mark = double.Parse(Console.ReadLine());

                if (mark<4.00)
                {
                    failCheck++;
                }

                allMarks += mark;

                grade++;
            }

            if (failCheck<2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {allMarks/12:f2}");
            }
        }
    }
}
