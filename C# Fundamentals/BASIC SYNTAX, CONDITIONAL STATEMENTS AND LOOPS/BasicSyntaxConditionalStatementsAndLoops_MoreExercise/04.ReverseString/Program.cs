using System;

namespace _04.ReverseString
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
            string input = Console.ReadLine();

            Console.WriteLine(ReverseString(input));
        }
    }
}
