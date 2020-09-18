using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string output = "";
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                int numberOfDigits = input.Length;
                int mainDigit = int.Parse(input[0].ToString());

                if (mainDigit==0)
                {
                    output = output + " ";
                    continue;
                }
                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }

                int letterIndex = offset + numberOfDigits - 1;
                char letter = (char)(letterIndex + 97);

                output = output + letter;
                
             }
            Console.WriteLine(output);

        }
    }
}
