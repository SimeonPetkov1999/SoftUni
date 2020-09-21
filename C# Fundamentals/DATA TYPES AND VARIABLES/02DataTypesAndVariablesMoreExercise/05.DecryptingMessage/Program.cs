using System;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());
            string result = string.Empty;
            int a = 0;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                char decripted = (char)(letter + key);

                //result += decripted;
                result = result.Insert(a++, decripted.ToString());
            }
            Console.WriteLine(result);
        }
    }
}
