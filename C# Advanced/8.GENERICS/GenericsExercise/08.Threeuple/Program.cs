using System;
using System.Linq;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split();
            var city = string.Join(" ",firstInput.Skip(3));
            var Threeuple1 = new Threeuple<string, string, string>
                ($"{firstInput[0]} {firstInput[1]}", firstInput[2], city);
            var secondInput = Console.ReadLine().Split();
            var isDrunk = secondInput[2] == "drunk" ? true : false;
            var Threeuple2 = new Threeuple<string, int, bool>
                (secondInput[0],int.Parse(secondInput[1]),isDrunk);
            var thirdInput = Console.ReadLine().Split();
            var Threeuple3 = new Threeuple<string, double, string>
                (thirdInput[0], double.Parse(thirdInput[1]), thirdInput[2]);

            Console.WriteLine(Threeuple1);
            Console.WriteLine(Threeuple2);
            Console.WriteLine(Threeuple3);
        }
    }
}
