using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double StrawberryPrice = double.Parse(Console.ReadLine());
            double BannanasKG = double.Parse(Console.ReadLine());
            double OrangesKG = double.Parse(Console.ReadLine());
            double BerriesKG = double.Parse(Console.ReadLine());
            double StrawberryKG = double.Parse(Console.ReadLine());

            double BerriesPrice = StrawberryPrice / 2;
            double OrangesPrice = BerriesPrice - (BerriesPrice * 0.4);
            double BannanasPrice = BerriesPrice - (BerriesPrice * 0.8);

            double PriceForAllBerries = BerriesPrice * BerriesKG;
            double PriceForAllOranges = OrangesPrice * OrangesKG;
            double PriceForAllBannanas = BannanasPrice * BannanasKG;
            double PriceForAllStrawberries = StrawberryPrice * StrawberryKG;

            double finalPrice = PriceForAllBannanas + PriceForAllBerries + PriceForAllOranges + PriceForAllStrawberries;

            Console.WriteLine(finalPrice);

        }
    }
}
