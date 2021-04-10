namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            this.fish = new Fish("Simo");
            this.aquarium = new Aquarium("Test", 5);
        }

        [Test]
        public void AquariumConstructorWorkingFine()
        {
            Assert.That(this.aquarium.Name, Is.EqualTo("Test"));
            Assert.That(this.aquarium.Capacity, Is.EqualTo(5));
            Assert.That(this.aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void ExeptionThtownWIthNullOrEmtyName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium("", 5);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium(null, 5);
            });
        }

        [Test]
        public void ExeptionThtownWIthnegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var aquarium = new Aquarium("Test", -5);
            });
        }

        [Test]
        public void AddShouldThrowExeptionIfCapacityIsFull()
        {
            var aquarium = new Aquarium("Test", 1);
            aquarium.Add(new Fish("test"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("test2"));
            });
        }

        [Test]
        public void AddWorkingFine()
        {
            this.aquarium.Add(fish);
            this.aquarium.Add(new Fish("Test"));
            Assert.That(this.aquarium.Count, Is.EqualTo(2));
        }

        [Test]
        public void RemoveFishShouldThrowExeptionIfFishDontExists()
        {
            this.aquarium.Add(this.fish);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("NoExistingFish");
            });
        }

        [Test]
        public void RemoveWorkingFine()
        {
            this.aquarium.Add(fish);
            this.aquarium.Add(new Fish("Test"));
            Assert.That(this.aquarium.Count, Is.EqualTo(2));
            this.aquarium.RemoveFish("Test");
            Assert.That(this.aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void SellFishShouldTHrowExeptionIfFishDontExist()
        {
            this.aquarium.Add(this.fish);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("NoExistingFish");
            });
        }

        [Test]
        public void SellFishWorkingFine()
        {
            this.aquarium.Add(fish);
            var soldFish = this.aquarium.SellFish("Simo");
            Assert.That(soldFish.Available, Is.EqualTo(false));
            Assert.That(ReferenceEquals(this.fish, soldFish));
        }

        [Test]
        public void ReportWorkingFine()
        {
            this.aquarium.Add(fish);
            this.aquarium.Add(new Fish("Ivan"));
            var expectedString = $"Fish available at {this.aquarium.Name}: Simo, Ivan";
            var result = this.aquarium.Report();
            Assert.That(result, Is.EqualTo(expectedString));
        }
    }
}
