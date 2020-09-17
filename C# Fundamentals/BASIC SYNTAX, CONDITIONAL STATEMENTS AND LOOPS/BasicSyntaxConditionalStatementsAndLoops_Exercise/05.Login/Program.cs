using System;

namespace _05.Login
{
    class Program
    {
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = ReverseString(username);
            int tries = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input==password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                tries++;
                if (tries==4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");            
            }         
        }
    }
}
