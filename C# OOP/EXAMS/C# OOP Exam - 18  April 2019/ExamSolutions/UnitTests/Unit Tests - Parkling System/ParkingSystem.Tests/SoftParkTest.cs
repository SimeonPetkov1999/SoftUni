using NUnit.Framework;
using System;

namespace ParkingSystem.Tests
{ 
    public class SoftParkTest
    {
        private SoftPark park;
        private Car car;

        [SetUp]
        public void SetUp() 
        {
            this.park = new SoftPark();
            this.car = new Car("Audi", "1111");
        }

        [Test]
        public void TestConstructor() 
        {
            Assert.That(park.Parking.Count, Is.EqualTo(12));
        }

        [Test]
        public void ParkCarShouldThrowExeptionIfParkingSpotDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.park.ParkCar("notExistingSpot", this.car);
            });
        }

        [Test]
        public void ParkCarShouldThrowExeptionIfSpotIsTaken()
        {
            this.park.ParkCar("A1", this.car);
            Assert.Throws<ArgumentException>(() =>
            {
                this.park.ParkCar("A1", new Car("test","test"));
            });
        }

        [Test]
        public void ParkCarShouldThrowExeptionIfCarExist()
        {
            this.park.ParkCar("A1", this.car);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.park.ParkCar("A2", this.car);
            });
        }

        [Test]
        public void ParkCarWorkingProperly()
        {
            this.park.ParkCar("A1", this.car);
            Assert.That(this.park.Parking["A1"], Is.EqualTo(this.car));
        }

        [Test]
        public void RemoveCarShouldThrowExeptionIfParkingSpotDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.park.RemoveCar("notExistingSpot", this.car);
            });
        }

        [Test]
        public void RemoveCarShouldThrowExeptionIfCarIsDifferent()
        {
            this.park.ParkCar("A1", this.car);
            Assert.Throws<ArgumentException>(() =>
            {
                this.park.RemoveCar("A1", new Car("test","test"));
            });
        }

        [Test]
        public void RemoveCarWorkingProperly()
        {
            this.park.ParkCar("A1", this.car);
            this.park.RemoveCar("A1", this.car);
            Assert.That(this.park.Parking["A1"], Is.EqualTo(null));
        }




    }
}