namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            this.present = new Present("test", 20);
            this.bag = new Bag();
        }

        [Test]
        public void ConstructorTest()
        {
            var bag = new Bag();
            Assert.That(bag.GetPresents().Count, Is.EqualTo(0));
        }

        [Test]
        public void CreatePresentShouldThrowExeptionIfNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.bag.Create(null);
            });
        }

        [Test]
        public void CreatePresentShouldThrowExeptionIfPresentExists()
        {
            this.bag.Create(this.present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.bag.Create(this.present);
            });
        }

        [Test]
        public void CreatePresentWorkingFine()
        {
            var resultString = this.bag.Create(this.present);
            var expectedString = $"Successfully added present {this.present.Name}.";
            Assert.That(bag.GetPresents().Count, Is.EqualTo(1));
            Assert.That(resultString, Is.EqualTo(expectedString));
        }

        [Test]
        public void RemoveTests()
        {
            this.bag.Create(this.present);
            Assert.That(bag.Remove(this.present), Is.True);
            Assert.That(bag.Remove(new Present("test",25)), Is.False);
        }

        [Test]
        public void GetPresentWithLeastMagic()
        {
            var testPresent = new Present("test", 50);
            this.bag.Create(this.present);
            this.bag.Create(testPresent);
            Assert.That(ReferenceEquals(bag.GetPresentWithLeastMagic(),this.present));          
        }

        [Test]
        public void GetPresentTest()
        {
            var testPresent = new Present("Test", 50);
            this.bag.Create(this.present);
            this.bag.Create(testPresent);
            Assert.That(ReferenceEquals(bag.GetPresent("Test"), testPresent));
            Assert.That(this.bag.GetPresent("NotExistingPresent"),Is.Null);
        }
    }
}
