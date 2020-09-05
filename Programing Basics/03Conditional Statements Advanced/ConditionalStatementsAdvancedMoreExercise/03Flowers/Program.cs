using System;

namespace _03Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfHrizantemi = int.Parse(Console.ReadLine());
            int numbersOfRoses = int.Parse(Console.ReadLine());
            int numbersOfLaleta = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char yesOrNo = char.Parse(Console.ReadLine());
            int numberOfAllFlowers = numbersOfHrizantemi + numbersOfLaleta + numbersOfRoses;

            double priceForRoses = 0.0;
            double priceForHrizantemi = 0.0;
            double priceForLaleta = 0.0;

            double finalPrice = 0.0;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    priceForHrizantemi = 2.00;
                    priceForRoses = 4.10;
                    priceForLaleta = 2.50;
                    break;
                case "Autumn":
                case "Winter":
                    priceForHrizantemi = 3.75;
                    priceForRoses = 4.50;
                    priceForLaleta = 4.15;
                    break;
            }

            finalPrice = (priceForHrizantemi * numbersOfHrizantemi) + (priceForRoses * numbersOfRoses) + (priceForLaleta * numbersOfLaleta);

            if (yesOrNo =='Y')
            {
                finalPrice *= 1.15;
            }

            if (numbersOfLaleta>=7 && season=="Spring")
            {
                finalPrice *= 0.95;
            }

            if (numbersOfRoses>=10 && season=="Winter")
            {
                finalPrice *= 0.90;
            }

            if (numberOfAllFlowers>20)
            {
                finalPrice *= 0.80;
            }

            finalPrice += 2;

            Console.WriteLine($"{finalPrice:f2}");


        }
    }
}
