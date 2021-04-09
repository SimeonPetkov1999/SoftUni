using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ContructorTest()
        {
            var manager = new ComputerManager();

            Assert.That(manager.Count, Is.EqualTo(0));
            Assert.That(manager.Computers.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddShoudlThrowExeptionIfNull()
        {
            var manager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.AddComputer(null);
            });
            
        }
        [Test]
        public void AddShoudlThrowExeptionIfCoputerExists()
        {
            var manager = new ComputerManager();
            manager.AddComputer(new Computer("Test", "Test", 50));

            Assert.Throws<ArgumentException>(() =>
            {
                manager.AddComputer(new Computer("Test", "Test", 20));
            });

        }

        [Test]
        public void AddWorkingFine()
        {
            var manager = new ComputerManager();
            manager.AddComputer(new Computer("Test", "Test", 50));
            manager.AddComputer(new Computer("Test1", "Test1", 50));
            manager.AddComputer(new Computer("Test2", "Test1", 50));

            Assert.That(manager.Count, Is.EqualTo(3));
        }

        [Test]
        [TestCase(null,"Test")]
        [TestCase("Test",null)]
        public void RemoveShoudlThrowExeptionIfNull(string manufacturer,string model)
        {
            var manager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.RemoveComputer(manufacturer,model);
            });

        }

        [Test]

        public void RemoveShoudlThrowExeptionIComputerDoesNotExist()
        {
            var manager = new ComputerManager();
            manager.AddComputer(new Computer("Test", "Test", 50));
            Assert.Throws<ArgumentException>(() =>
            {
                manager.RemoveComputer("NotExisting", "NotExistingModel");
            });
        }

        [Test]
        public void RemoveWorkingFIne()
        {
            var manager = new ComputerManager();
            var computer = new Computer("Test", "Test", 50);
            var computer1 = new Computer("Test1", "Test1", 50);
            var computer2 = new Computer("Test2", "Test2", 50);
            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);


            Assert.That(manager.RemoveComputer("Test","Test"), Is.EqualTo(computer));
        }

        [Test]
        public void GetComputersByManufacturerShouldThrowExeptionIfNull()
        {
            var manager = new ComputerManager();         
            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.GetComputersByManufacturer(null);
            });
        }

        [Test]
        public void GetComputersByManufacturerWorkingFine()
        {
            var manager = new ComputerManager();
            var computer = new Computer("Test", "Test", 50);
            var computer1 = new Computer("Test", "Test1", 50);
            var computer2 = new Computer("Test2", "Test2", 50);
            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            Assert.That(manager.GetComputersByManufacturer("Test").Count, Is.EqualTo(2));
        }
    }
}