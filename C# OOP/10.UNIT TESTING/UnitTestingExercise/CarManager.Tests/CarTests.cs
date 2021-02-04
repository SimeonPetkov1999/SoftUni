using NUnit.Framework;

namespace Tests
{
    using CarManager;
    using System;

    public class CarTests
    {
        private Car car;
        private const string Make = "Audi";
        private const string Model = "Audi";
        private const double FuelConsuption = 7.5;
        private const double FuelCapacity = 60;
        private const double FuelAmount = 0;
        [SetUp]
        public void Setup()
        {
            this.car = new Car(Make, Model, FuelConsuption, FuelCapacity);
        }

        [Test]
        public void ConstructorShouldSetAllValues()
        {
            Assert.That(this.car.Make, Is.EqualTo(Make),
                this.car.Model, Is.EqualTo(Model),
                this.car.FuelConsumption, Is.EqualTo(FuelConsuption),
                this.car.FuelCapacity, Is.EqualTo(FuelCapacity),
                this.car.FuelAmount, Is.EqualTo(FuelAmount));
        }

        [TestCase(null, Model, FuelConsuption, FuelCapacity)]
        [TestCase(Make, null, FuelConsuption, FuelCapacity)]
        [TestCase(Make, Model, 0, FuelCapacity)]
        [TestCase(Make, Model, FuelConsuption, 0)]
        public void ConstructorWithAnyNullArgShouldThorowExeption(string make, string model, double fuelConsuption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsuption, fuelCapacity);
            });
        }

        [TestCase(-10)]
        [TestCase(0)]
        public void RefuelWithNegativeValueShouldThrowExeption(double refuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(refuel);
            });
        }

        [Test]
        public void RefuelShouldChangeFuelAmount()
        {
            this.car.Refuel(10);
            Assert.That(this.car.FuelAmount, Is.EqualTo(10));
        }

        [Test]
        public void RefuelWithMoreThanCapacityShouldSetAmountToCapacity()
        {
            this.car.Refuel(100);
            Assert.That(this.car.FuelAmount, Is.EqualTo(FuelCapacity));
        }

        [Test]
        public void DriveShouldThrowExeptionIfNotEnoughFuelInTheCar()
        {
            this.car.Refuel(30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(500);
            });
        }

        [TestCase(20)]
        public void DriveDecreseFuelAmount(double distance)
        {
            this.car.Refuel(60);
            double fuelNeeded =(distance / 100) * FuelConsuption;
            double expected = this.car.FuelAmount - fuelNeeded;
            this.car.Drive(distance);

            Assert.That(this.car.FuelAmount, Is.EqualTo(expected));

        }

    }
}