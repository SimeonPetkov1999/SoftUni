using System;

namespace _01ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double yuans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine()) / 100;

            double levs = bitcoins * 1168;
            double usd = yuans * 0.15;
            levs = levs + (usd * 1.76);

            double euro = levs / 1.95;
            euro = euro - (euro * commission);

            Console.WriteLine($"{euro:f2}");
        }
    }
}
