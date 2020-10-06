using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           
            while (input!="END")
            {
                Console.WriteLine(IsPalindrome(input));

                input = Console.ReadLine();
            }
            

        }

        static string IsPalindrome(string input)
        {
            for (int i = 0; i < input.Length/2; i++)
            {
                if (input[i]==input[input.Length-i-1])
                {
                    continue;
                } 

                else
                {
                    return "false";
                }
            }

            return "true";
        }
    }
}
