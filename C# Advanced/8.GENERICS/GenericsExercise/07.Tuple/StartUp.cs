using System;

namespace _07.Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split();
            var myTuple1 = new MyTuple<string, string>($"{firstInput[0]} {firstInput[1]}", firstInput[2]);
            var secondInput = Console.ReadLine().Split();
            var myTuple2 = new MyTuple<string, int>(secondInput[0], int.Parse(secondInput[1]));
            var thirdInput = Console.ReadLine().Split();
            var myTuple3 = new MyTuple<int, double>(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));

            Console.WriteLine(myTuple1);
            Console.WriteLine(myTuple2);
            Console.WriteLine(myTuple3);
        }
    }
}
