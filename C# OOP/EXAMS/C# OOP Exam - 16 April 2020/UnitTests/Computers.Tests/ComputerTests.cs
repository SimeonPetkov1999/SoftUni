namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ContructorShouldThrowExceptionIfNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var computer = new Computer(null);
            });
        }

        [Test]
        public void ContructorWorkingFine()
        {
            var computer = new Computer("Test");
            Assert.That(computer.Name, Is.EqualTo("Test"));
            Assert.That(computer.Parts.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddPartShouldThrowExeptionIfPartIsNull()
        {
            var computer = new Computer("Test");

            Assert.Throws<InvalidOperationException>(() =>
            {
                computer.AddPart(null);
            });
        }

        [Test]
        public void AddPartWorkingFine()
        {
            var computer = new Computer("Test");
            computer.AddPart(new Part("test", 10));
            computer.AddPart(new Part("test1", 20));
            Assert.That(computer.Parts.Count, Is.EqualTo(2));
        }


        [Test]
        public void SumTest()
        {
            var computer = new Computer("Test");
            computer.AddPart(new Part("test", 10));
            computer.AddPart(new Part("test1", 20));
            Assert.That(computer.TotalPrice, Is.EqualTo(30));
        }

        [Test]
        public void RemovePart()
        {
            var part = new Part("test", 10);
            var computer = new Computer("Test");
            computer.AddPart(part);
            Assert.That(computer.RemovePart(part), Is.True);
            Assert.That(computer.RemovePart(new Part("test",5)), Is.False);
        }

        [Test]
        public void GetPartTest()
        {
            var part = new Part("testPart", 10);
            var computer = new Computer("Test");
            computer.AddPart(part);
            Assert.That(computer.GetPart("testPart"), Is.EqualTo(part));
            Assert.That(computer.GetPart("NotExistingPart"), Is.Null);
        }
    }
}