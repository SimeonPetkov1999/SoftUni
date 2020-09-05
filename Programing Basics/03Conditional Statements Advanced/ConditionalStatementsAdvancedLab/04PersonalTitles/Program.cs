using System;

namespace _04PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());

            switch (gender)
            {
                case 'm':
                    if (age<16)
                    {
                        Console.WriteLine("Master");
                    }

                    else
                    {
                        Console.WriteLine("Mr.");
                    }
                    break;
                default:
                    if (age<16)
                    {
                        Console.WriteLine("Miss");
                    }

                    else
                    {
                        Console.WriteLine("Ms.");
                    }
                    break;
            }
        }
    }
}
