using System;

namespace _08Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForMonth = double.Parse(Console.ReadLine());
            double averageUspeh = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());
            double getSocialScholarship = 0.0;
            double getUspehScholarship = 0.0;

            if (averageUspeh <= 4.5 || (moneyForMonth > minimalSalary && averageUspeh < 5.5))
            {
               Console.WriteLine("You cannot get a scholarship!");
               Environment.Exit(0);
            }

            if ((averageUspeh > 4.5 && averageUspeh < 5.5) && moneyForMonth <= minimalSalary) 
            {
                getSocialScholarship = minimalSalary * 0.35;
                Console.WriteLine($"You get a Social scholarship {Math.Floor(getSocialScholarship)} BGN");
                Environment.Exit(0);
            }

            if (averageUspeh >= 5.5 && moneyForMonth > minimalSalary)
            {
                getUspehScholarship = averageUspeh * 25;
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(getUspehScholarship)} BGN");
                Environment.Exit(0);
            }


            if (averageUspeh >= 5.5 && moneyForMonth <= minimalSalary)
            {
                getUspehScholarship = averageUspeh * 25;
                getSocialScholarship = minimalSalary * 0.35;

                if (getSocialScholarship > getUspehScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(getSocialScholarship)} BGN");
                }
                else if (getSocialScholarship < getUspehScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(getUspehScholarship)} BGN");
                }

                else if(getSocialScholarship == getUspehScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(getUspehScholarship)} BGN");
                }            
            }

        }
    }
}
