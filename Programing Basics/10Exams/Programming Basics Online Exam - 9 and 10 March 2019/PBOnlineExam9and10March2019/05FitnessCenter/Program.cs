using System;

namespace _05FitnessCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleInTheGym = int.Parse(Console.ReadLine());
            int back = 0;
            int chest = 0;
            int legs = 0;
            int abs = 0;
            int proteinShake = 0;
            int ProteinBar = 0;
            int peopleTraining = 0;
            int peopleBuying = 0;

            for (int i = 0; i < peopleInTheGym; i++)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "Back":
                        back++;
                        peopleTraining++;
                        break;
                    case "Chest":
                        chest++;
                        peopleTraining++;
                        break;
                    case "Legs":
                        legs++;
                        peopleTraining++;
                        break;
                    case "Abs":
                        abs++;
                        peopleTraining++;
                        break;
                    case "Protein shake":
                        proteinShake++;
                        peopleBuying++;
                        break;
                    case "Protein bar":
                        ProteinBar++;
                        peopleBuying++;
                        break;
                }
            }

            Console.WriteLine($"{back} - back");
            Console.WriteLine($"{chest} - chest");
            Console.WriteLine($"{legs} - legs");
            Console.WriteLine($"{abs} - abs");
            Console.WriteLine($"{proteinShake} - protein shake");
            Console.WriteLine($"{ProteinBar} - protein bar");
            double peopleWorkOut = (peopleTraining * 1.0 / peopleInTheGym) * 100;
            double peopleBuyingProteins = (peopleBuying * 1.0 / peopleInTheGym) * 100;
            Console.WriteLine($"{peopleWorkOut:f2}% - work out");
            Console.WriteLine($"{peopleBuyingProteins:f2}% - protein");



        }
    }
}
