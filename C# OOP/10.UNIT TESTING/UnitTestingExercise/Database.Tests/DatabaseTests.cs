using NUnit.Framework;

namespace Tests
{
    using Database;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] InvalidLenghtArr = new int[17];
        private int[] FullLenghtArr = new int[16];
        private Database db;
        [SetUp]
        public void Setup()
        {
            this.db = new Database(1, 2);
        }

        [Test]
        public void ConstructorShouldThrowExeptionIfMoreThan16ParamLenght()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                new Database(this.InvalidLenghtArr);
            });
        }

        [Test]
        public void AddShouldIncrementDbCount()
        {
            db.Add(1);
            Assert.That(db.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddShouldThrowsExeptionIfTriedToAdd17thElement()//?
        {
            this.db = new Database(this.FullLenghtArr);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(1);
            });
        }

        [Test]
        public void RemovingFromEmptyDatabaseShouldThrowExeption()
        {
            this.db = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            });
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 })]
        public void RemovingFromDatabaseShouldDecreaseCount(int[] data)
        {
            this.db = new Database(data);
            var count = db.Count;
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(count - 1));
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        public void FetchShouldReturnArray(int[] data)
        {
            this.db = new Database(data);
            var fetched = db.Fetch();


            Assert.That(fetched.Length, Is.EqualTo(db.Count));
            CollectionAssert.AreEqual(data,fetched);
        }
    }
}