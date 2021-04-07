namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    
    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorSHouldThrowExceptionIfCapacityIsNegative() 
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var manager = new RobotManager(-10);
            });
        }

        [Test]
        public void ConstructorWorkingFine()
        {
            var manager = new RobotManager(10);

            Assert.That(manager.Capacity, Is.EqualTo(10));
            Assert.That(manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddRobotShouldThrowExceptionIfNameExist()
        {
            var manager = new RobotManager(5);
            manager.Add(new Robot("Test", 5000));
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(new Robot("Test", 1000));
            });
        }

        [Test]
        public void AddRobotShouldThrowExceptionIfNotEnoughCapacity()
        {
            var manager = new RobotManager(1);
            manager.Add(new Robot("Test", 5000));
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(new Robot("Test1", 1000));
            });
        }

        [Test]
        public void AddRobotWorkingFine()
        {
            var manager = new RobotManager(10);
            manager.Add(new Robot("Test1", 1000));
            manager.Add(new Robot("Test2", 1000));
            manager.Add(new Robot("Test3", 1000));

            Assert.That(manager.Count, Is.EqualTo(3));
        }

        [Test]
        public void RemoveShouldThrowExeptionIfNameDoesNotExists()
        {
            var manager = new RobotManager(5);
            manager.Add(new Robot("Test", 5000));
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove("NotExistingName");
            });
        }

        [Test]
        public void RemoveWorkingFine()
        {
            var manager = new RobotManager(10);
            manager.Add(new Robot("Test1", 1000));
            manager.Add(new Robot("Test2", 1000));
            manager.Add(new Robot("Test3", 1000));

            Assert.That(manager.Count, Is.EqualTo(3));
            manager.Remove("Test1");
            Assert.That(manager.Count, Is.EqualTo(2));
        }

        [Test]
        public void WorkShouldThrowExeptionIfNameDoesNotExist()
        {
            var manager = new RobotManager(5);
            manager.Add(new Robot("Test", 5000));
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("NotExistingName", "test", 500);
            });
        }

        [Test]
        public void WorkShouldThrowExeptionIfNotEnoughEnergy()
        {
            var manager = new RobotManager(5);
            manager.Add(new Robot("Test", 150));
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("Test", "test", 500);
            });
        }

        [Test]
        public void WorkWorkingFine()
        {
            var manager = new RobotManager(10);
            var testRobot1 = new Robot("Test1", 1000);
            var testRobot2 = new Robot("Test2", 1000);
            var testRobot3 = new Robot("Test3", 1000);

            manager.Add(testRobot1);
            manager.Add(testRobot2);
            manager.Add(testRobot3);

            manager.Work("Test1", "testJob", 500);
            manager.Work("Test2", "testJob", 250);
            manager.Work("Test3", "testJob", 50);

            Assert.That(testRobot1.Battery, Is.EqualTo(500));
            Assert.That(testRobot2.Battery, Is.EqualTo(750));
            Assert.That(testRobot3.Battery, Is.EqualTo(950));
            
        }

        [Test]
        public void ChargeShouldThrowExceptionIfNameDoesNotExist()
        {
            var manager = new RobotManager(5);
            manager.Add(new Robot("Test", 150));
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge("NotExistingName");
            });
        }

        [Test]
        public void ChargeWorkingFine()
        {
            var manager = new RobotManager(10);
            var testRobot1 = new Robot("Test1", 1000);
            var testRobot2 = new Robot("Test2", 1000);

            manager.Add(testRobot1);
            manager.Add(testRobot2);

            Assert.That(testRobot1.Battery, Is.EqualTo(1000));
            Assert.That(testRobot2.Battery, Is.EqualTo(1000));

            manager.Work("Test1", "testJob", 500);
            manager.Work("Test2", "testJob", 250);

            Assert.That(testRobot1.Battery, Is.EqualTo(500));
            Assert.That(testRobot2.Battery, Is.EqualTo(750));

            manager.Charge("Test1");
            manager.Charge("Test2");

            Assert.That(testRobot1.Battery, Is.EqualTo(1000));
            Assert.That(testRobot2.Battery, Is.EqualTo(1000));

        }



    }
}
