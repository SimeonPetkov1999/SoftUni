using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            this.car = new UnitCar("Audi", 150, 2000);
            this.driver = new UnitDriver("Simo", this.car);
            this.race = new RaceEntry();
        }

        [Test]
        public void UnitCarConstructorShouldSetValues()
        {
            Assert.That(this.car.Model, Is.EqualTo("Audi"));
            Assert.That(this.car.HorsePower, Is.EqualTo(150));
            Assert.That(this.car.CubicCentimeters, Is.EqualTo(2000));
        }

        [Test]
        public void UnitDricerConstructorShouldSetValues()
        {
            Assert.That(this.driver.Name, Is.EqualTo("Simo"));
            Assert.That(this.driver.Car, Is.EqualTo(car));
           
        }

        [Test]
        public void UnitDricerConstructorShouldThrowExeptionIfNameIsNull()
        {           
            Assert.Throws<ArgumentNullException>(() =>
            {
                var diver = new UnitDriver(null, this.car);
            });          
        }

        [Test]
        public void RaceEntryConstructorShouldCounterTo0()
        {
            Assert.That(this.race.Counter, Is.EqualTo(0));
       }
        [Test]
        public void AddDriverThrowExeptionIfDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.AddDriver(null);
            });
        }
        [Test]
        public void AddDriverThrowExeptionIfDriverWithSameName()
        {
            this.race.AddDriver(this.driver);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.AddDriver(this.driver);
            });
        }

        [Test]
        public void AddDriverTShouldIncreaseCount()
        {
            this.race.AddDriver(this.driver);
            Assert.That(this.race.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriverTShouldReturnMessage()
        {
            var message = this.race.AddDriver(this.driver);
            Assert.That(message, Is.EqualTo($"Driver {this.driver.Name} added in race."));
        }

        [Test]
        public void CalculateAverageThrowExeptionIfDriversAreLessThan2()
        {
            this.race.AddDriver(this.driver);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void CalculateAverageShouldReturnAverage()
        {
            this.race.AddDriver(this.driver);
            this.race.AddDriver(new UnitDriver("Pesho",new UnitCar("VW",150,1600)));
            var average = this.race.CalculateAverageHorsePower();
            Assert.That(average, Is.EqualTo(150));
        }

    }
}