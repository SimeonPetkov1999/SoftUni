using System;

namespace _02BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfJuniorBikers = int.Parse(Console.ReadLine());
            int numberOfSeniorBikers = int.Parse(Console.ReadLine());
            string typeOfRace = Console.ReadLine();
            int allBikers = numberOfSeniorBikers + numberOfJuniorBikers;
            double sumForJuniors = 0.0;
            double sumForSeniors = 0.0;
            double finalSum = 0.0;

           switch (typeOfRace)
            {
                case "trail":
                    sumForJuniors = numberOfJuniorBikers * 5.50;
                    sumForSeniors = numberOfSeniorBikers * 7;
                    break;
                case "cross-country":         
                        sumForJuniors = numberOfJuniorBikers * 8.0;
                        sumForSeniors = numberOfSeniorBikers * 9.50;                 
                    break;
                case "downhill":
                    sumForJuniors = numberOfJuniorBikers * 12.25;
                    sumForSeniors = numberOfSeniorBikers * 13.75;
                    break;
                default:
                    sumForJuniors = numberOfJuniorBikers * 20;
                    sumForSeniors = numberOfSeniorBikers * 21.50;
                    break;
            }

            finalSum = sumForJuniors + sumForSeniors;

            if (allBikers >= 50 && typeOfRace == "cross-country")
            {
                finalSum *= 0.75;
            }

            finalSum *= 0.95;

            Console.WriteLine($"{finalSum:f2}");



        }
    }
}
