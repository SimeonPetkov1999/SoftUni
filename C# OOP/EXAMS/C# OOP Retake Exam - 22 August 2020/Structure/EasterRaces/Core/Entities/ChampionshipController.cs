using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository carRepo;
        private DriverRepository driverRepo;
        private RaceRepository raceRepo;
        public ChampionshipController()
        {
            this.carRepo = new CarRepository();
            this.driverRepo = new DriverRepository();
            this.raceRepo = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.driverRepo.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            var car = this.carRepo.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }
            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.raceRepo.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var driver = this.driverRepo.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var car = this.carRepo.GetByName(model);
            if (car != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            ICar carToAdd = null;
            if (type == "Muscle")
            {
                carToAdd = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                carToAdd = new SportsCar(model, horsePower);
            }
            this.carRepo.Add(carToAdd);
            return $"{type}Car {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var car = this.driverRepo.GetByName(driverName);
            if (car != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            this.driverRepo.Add(new Driver(driverName));
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = this.raceRepo.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
            this.raceRepo.Add(new Race(name, laps));
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepo.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (race.Drivers.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var drivers = race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine($"Driver {drivers[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {drivers[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {drivers[2].Name} is third in {race.Name} race.");
            this.raceRepo.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
