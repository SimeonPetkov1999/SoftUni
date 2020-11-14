using System;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <n; i++)
            {
                string input = Console.ReadLine();
                int lenghtName = input.IndexOf('|') - input.IndexOf('@');
                int lenghtAge = input.IndexOf('*') - input.IndexOf('#');
                string name = input.Substring(input.IndexOf('@')+1, lenghtName-1);
                string age = input.Substring(input.IndexOf('#')+1, lenghtAge-1);
                Console.WriteLine($"{name} is {age} years old.");
                ;
            }
        }
    }
}
