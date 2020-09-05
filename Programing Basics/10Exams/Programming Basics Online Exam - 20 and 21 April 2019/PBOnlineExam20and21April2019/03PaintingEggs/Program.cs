using System;

namespace _03PaintingEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfEgg = Console.ReadLine();
            string colorOfEgg = Console.ReadLine();
            int partidi = int.Parse(Console.ReadLine());

            double PriceForPartida = 0.0;
            double FinalPrice = 0.0;

            if (colorOfEgg == "Red")
            {
                if (typeOfEgg == "Large")
                {
                    PriceForPartida = 16;
                }

                else if (typeOfEgg == "Medium")
                {
                    PriceForPartida = 13;
                }

                else
                {
                    PriceForPartida = 9;
                }
            }

            if (colorOfEgg == "Green")
            {
                if (typeOfEgg == "Large")
                {
                    PriceForPartida = 12;
                }

                else if (typeOfEgg == "Medium")
                {
                    PriceForPartida = 9;
                }

                else
                {
                    PriceForPartida = 8;
                }

            }

            if (colorOfEgg == "Yellow")
            {
                if (typeOfEgg == "Large")
                {
                    PriceForPartida = 9;
                }

                else if (typeOfEgg == "Medium")
                {
                    PriceForPartida = 7;
                }

                else
                {
                    PriceForPartida = 5;
                }

            }

            FinalPrice = (PriceForPartida * partidi) * 0.65;

            Console.WriteLine($"{FinalPrice:f2} leva.");


        }
    }
}
