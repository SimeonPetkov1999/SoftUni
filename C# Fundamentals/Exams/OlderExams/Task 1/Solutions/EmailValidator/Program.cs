using System;
using System.Text;

namespace EmailValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] commandArgs = Console.ReadLine().Split();

            while (commandArgs[0] != "Complete")
            {     
                if (commandArgs[0] == "GetDomain")
                {
                    int count = int.Parse(commandArgs[1]);
                    lastCountElements(input, count);
                }
                else if (commandArgs[0] == "GetUsername")
                {
                    getUsername(input);
                }
                else if (commandArgs[0] == "Encrypt")
                {
                    encrypt(input);
                }
                else if (commandArgs[0] =="Replace")
                {
                    char old = char.Parse(commandArgs[1]);
                    input = input.Replace(old, '-');
                    Console.WriteLine(input);
                }
                else if (commandArgs[1] == "Upper")
                {
                    input = toUpper(input);
                }
                else if (commandArgs[1] == "Lower")
                {
                    input = toLower(input);
                }
                commandArgs = Console.ReadLine().Split();
            }
        }

        public static string toUpper(string input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(input);
            for (int i = 0; i < input.Length; i++)
            {
                sb[i] = char.ToUpper(input[i]);
            }

            return sb.ToString();
        }

        public static string toLower(string input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(input);
            for (int i = 0; i < input.Length; i++)
            {
                sb[i] = char.ToLower(input[i]);
            }

            return sb.ToString();
        }

        public static void lastCountElements(string input, int count)
        {
            Console.WriteLine(input.Substring(input.Length - count));
        }

        public static void getUsername(string input)
        {
            int index = input.IndexOf('@');
            if (index == -1)
            {
                Console.WriteLine($"The email {input} doesn't contain the @ symbol.");
            }
            else
            {
                Console.WriteLine(input.Substring(0, index));
            }
        }
        public static void encrypt(string input) 
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write((int)input[i] + " ");
            }
        }

    }
}
