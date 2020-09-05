using System;

namespace _02Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string password = Console.ReadLine();

            string inputPassword = Console.ReadLine();

            while (inputPassword!=password)
            {
                inputPassword = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {user}!");
        }
    }
}
