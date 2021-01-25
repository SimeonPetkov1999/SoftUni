using System;

namespace _09.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0]=="End")
                {
                    break;
                }

                var name = input[0];
                var country = input[1];
                var age = int.Parse(input[2]);

                //IPerson Personcitizen = new Citizen(name, country, age);
                //IResident Residentcitizen = new Citizen(name, country, age);
                //Console.WriteLine(Personcitizen.GetName());
                //Console.WriteLine(Residentcitizen.GetName());

                var citizen = new Citizen(name, country, age);
              
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
