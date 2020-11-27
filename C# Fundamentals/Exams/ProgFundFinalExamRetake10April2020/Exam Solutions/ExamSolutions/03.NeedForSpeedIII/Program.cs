using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split("|");
                string car = line[0];
                int mileage = int.Parse(line[1]);
                int fuel = int.Parse(line[2]);
                cars.Add(car, new Car(mileage, fuel));//?
            }

            string[] commandsArgs = Console.ReadLine().Split(" : ");
            while (commandsArgs[0]!="Stop")
            {

                string command = commandsArgs[0];
                string car = commandsArgs[1];
                if (command=="Drive")
                {                 
                    int distance = int.Parse(commandsArgs[2]);
                    int fuel = int.Parse(commandsArgs[3]);

                    if (cars[car].Fuel<fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car].Mileage += distance;
                        cars[car].Fuel -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (cars[car].Mileage>100000)
                        {
                            Console.WriteLine($"Time to sell the {car}! ");
                            cars.Remove(car);
                        }
                    }
                }

                else if (command=="Refuel")
                {
                    int fuel = int.Parse(commandsArgs[2]);
                    if (cars[car].Fuel + fuel <= 75)
                    {
                        cars[car].Fuel += fuel;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                    else
                    {
                        cars[car].Fuel = 75;
                        Console.WriteLine($"{car} refueled with {75-fuel} liters");
                    }
                }
                else if (command=="Revert")
                {
                    int kilometers = int.Parse(commandsArgs[2]);

                    cars[car].Mileage -= kilometers;
                    if (cars[car].Mileage<10000)
                    {
                        cars[car].Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
                commandsArgs = Console.ReadLine().Split(" : ");
            }

            foreach (var item in cars.OrderByDescending(n=>n.Value.Mileage).ThenBy(n=>n.Key))
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value.Mileage} kms, Fuel in the tank: {item.Value.Fuel} lt.");
            }

        }
        public class Car 
        {

            public Car(int Mileage, int Fuel) 
            {
                this.Mileage = Mileage;
                this.Fuel = Fuel;
            }
            public int Mileage { get; set; }
            public int Fuel { get; set; }

        }
    }
}
