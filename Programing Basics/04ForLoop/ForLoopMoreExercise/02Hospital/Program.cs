using System;

namespace _02Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int numberOfTreatedPatients = 0;
            int numberOfUntreatedPatients = 0;
            int doctors = 7;
           

            for (int i = 1; i <= days; i++)
            {
                bool IsTrue = i % 3 == 0 && numberOfTreatedPatients < numberOfUntreatedPatients;
                if (IsTrue)
                {
                    doctors++;
                }

                int input = int.Parse(Console.ReadLine());

                if (input <= doctors)
                {
                    numberOfTreatedPatients += input;
                }

                else
                {
                    numberOfTreatedPatients += doctors;
                    numberOfUntreatedPatients += input - doctors;
                }
            }

            Console.WriteLine($"Treated patients: {numberOfTreatedPatients}.");
            Console.WriteLine($"Untreated patients: {numberOfUntreatedPatients}.");

        }
    }
}
