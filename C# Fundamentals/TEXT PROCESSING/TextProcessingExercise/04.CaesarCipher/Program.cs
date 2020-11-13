using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder text = new StringBuilder();


            foreach (var item in input)
            {
                text.Append((char)(item + 3));
            }

            Console.WriteLine(text);
        }
    }
}
