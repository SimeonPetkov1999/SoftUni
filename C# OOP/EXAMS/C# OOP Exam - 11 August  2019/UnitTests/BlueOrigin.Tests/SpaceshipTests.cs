namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Astronaut atro;
        private Spaceship spaceship;

        [SetUp]
        public void SetUp() 
        {
            this.spaceship = new Spaceship("Test", 10);

        }

        [Test]
        public void NameSHouldThrowExeptionIfEmpty() 
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.spaceship = new Spaceship("",5);
            });
        }

        [Test]
        public void NameWorkingFine()
        {
            Assert.That(this.spaceship.Name, Is.EqualTo("Test"));
        }

        [Test]
        public void CapacitySHouldThrowExeptionIfBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.spaceship = new Spaceship("test", -5);
            });
        }

        [Test]
        public void CapacityWorkingFine()
        {
            Assert.That(this.spaceship.Capacity, Is.EqualTo(10));
        }

        [Test]
        public void AddSHouldThrowExeptionIfNoMoreRoom()
        {
            this.spaceship = new Spaceship("test", 0);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(new Astronaut("test",100));
            });
        }

        [Test]
        public void AddSHouldThrowExeptionIfThereIsAstrounautWithSameName()
        {
            this.spaceship.Add(new Astronaut("test",500));
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(new Astronaut("test", 100));
            });
        }

        [Test]
        public void AddWorkingFine()
        {
            this.spaceship.Add(new Astronaut("test", 500));
            this.spaceship.Add(new Astronaut("test2", 500));
            Assert.That(this.spaceship.Count, Is.EqualTo(2));
        }

        [Test]
        public void RemoveShouldReturnFalseIFNameDoesNotExist()
        {
            this.spaceship.Add(new Astronaut("test", 500));
            this.spaceship.Add(new Astronaut("test2", 500));
            Assert.That(this.spaceship.Remove("NotExistingName"), Is.EqualTo(false));
        }

        [Test]
        public void RemoveShouldReturnTrueWhenRemove()
        {
            this.spaceship.Add(new Astronaut("test", 500));
            this.spaceship.Add(new Astronaut("test2", 500));
            Assert.That(this.spaceship.Remove("test"), Is.EqualTo(true));
            Assert.That(this.spaceship.Remove("test"), Is.EqualTo(false));
        }

    }
}