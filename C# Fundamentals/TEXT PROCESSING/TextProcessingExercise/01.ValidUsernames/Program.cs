using System;
using System.Collections.Generic;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            List<string> valid = new List<string>();

            bool isValid = false;
            foreach (var username in usernames)
            {
                int lenght = username.Length;
                if (lenght >= 3 && lenght <= 16)
                {
                    for (int i = 0; i < lenght; i++)
                    {
                        if (char.IsLetter(username[i]) || char.IsDigit(username[i]) || username[i] == '-' || username[i] == '_')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                {
                    valid.Add(username);
                }
                isValid = false;
            }

            foreach (var item in valid)
            {
                Console.WriteLine(item);
            }
        }
    }
}
