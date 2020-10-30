using System;

namespace _01.EasterCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double price1KGflour = double.Parse(Console.ReadLine());

            double priceFor1PackOfEggs = price1KGflour * 0.75;            
            double priceFor250mlMilk = (price1KGflour * 1.25)/4;

            double priceForCozunac = price1KGflour + priceFor1PackOfEggs + priceFor250mlMilk;

            int eggs = 0;
            int cozunacs = 0;


            while (budget>priceForCozunac)
            {
                budget -= priceForCozunac;
                cozunacs++;
                eggs += 3;

                if (cozunacs % 3 == 0)
                {
                    eggs = eggs - (cozunacs - 2);
                }
            }

            Console.WriteLine($"You made {cozunacs} cozonacs! Now you have {eggs} eggs and {budget:f2}BGN left.");

        }
    }
}
