using System;

namespace _05PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    for (char a = 'a'; a < 'a' + l; a++)
                    {
                        for (int b = 'a'; b < 'a' + l; b++)
                        {
                            for (int lastDigit = 1; lastDigit <=n ; lastDigit++)
                            {
                                if (lastDigit>i && lastDigit>j)
                                {
                                    Console.Write($"{i}{j}{a}{(char)b}{lastDigit}" + " ");
                                }
                                
                            }
                        
                        }
                    }
                }
            }

        }
    }
}
