using System;

namespace VetClinic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var clinic = new Clinic(20);
            var dog = new Pet("elieas", 5, "tim");
            Console.WriteLine(dog);
            clinic.Add(dog);
            Console.WriteLine(clinic.Remove("elieas"));
            Console.WriteLine(clinic.Remove("pufa"));

            Pet cat = new Pet("Bella", 2, "Mia");
            Pet bunny = new Pet("Zak", 4, "Jon");

            clinic.Add(cat);
            clinic.Add(bunny);

            Pet oldestPet = clinic.GetOldestPet();
            Console.WriteLine(oldestPet);

            Console.WriteLine(clinic.GetStatistics());
        }
    }
}
