using System;

namespace _03FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyOnHand = double.Parse(Console.ReadLine());
            char sex =char.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double priceForMounth=0;

            if (sport=="Gym")
            {
                if (sex =='m')
                {
                    priceForMounth = 42;
                }
                else
                {
                    priceForMounth = 35;
                }
            }

           else if (sport == "Boxing")
            {
                if (sex == 'm')
                {
                    priceForMounth = 41;
                }
                else
                {
                    priceForMounth = 37;
                }
            }

            else if(sport == "Yoga")
            {
                if (sex == 'm')
                {
                    priceForMounth = 45;
                }
                else
                {
                    priceForMounth = 42;
                }
            }
            else if (sport == "Zumba")
            {
                if (sex == 'm')
                {
                    priceForMounth = 34;
                }
                else
                {
                    priceForMounth = 31;
                }
            }
            else if (sport == "Dances")
            {
                if (sex == 'm')
                {
                    priceForMounth = 51;
                }
                else
                {
                    priceForMounth = 53;
                }
            }

            else if (sport == "Pilates")
            {
                if (sex == 'm')
                {
                    priceForMounth = 39;
                }
                else
                {
                    priceForMounth = 37;
                }
            }

            if (age <= 19)
            {
                priceForMounth = priceForMounth - (priceForMounth * 0.2);
            }
            if (moneyOnHand > priceForMounth)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}. ");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! Yo need ${priceForMounth-moneyOnHand:f2} more. ");
            }
        }
    }
}
