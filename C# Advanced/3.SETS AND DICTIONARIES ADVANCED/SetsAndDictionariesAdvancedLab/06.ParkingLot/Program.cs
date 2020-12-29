using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var plates = new HashSet<string>();

            var currentPlate = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (currentPlate[0] != "END")
            {
                string direction = currentPlate[0];
                string plate = currentPlate[1];
                if (direction == "IN")
                {
                    plates.Add(plate);
                }
                else if(direction=="OUT")
                {
                    plates.Remove(plate);
                }

                currentPlate = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (plates.Count>0)
            {
                foreach (var item in plates)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
