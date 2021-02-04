using NUnit.Framework;
using System;

namespace Tests
{
    using ExtendedDatabase;
    public class ExtendedDatabaseTests
    {
        private Person Pesho;
        private Person Gosho;
        private ExtendedDatabase db;

        [SetUp]
        public void Setup()
        {
            this.Pesho = new Person(123456789, "Pesho");
            this.Gosho = new Person(123456859, "Gosho");
            this.db = new ExtendedDatabase();
        }

        [Test]
        public void AddShouldThrowExeptionIfPersonWithUsernameAlreadyExist()
        {
            this.db.Add(this.Pesho);
            var SecondPesho = new Person(123456781, "Pesho");
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(SecondPesho);
            });
        }

        [Test]
        public void AddShouldThrowExeptionIfPersonWithIdAlreadyExist()
        {
            this.db.Add(this.Gosho);
            var SecondGosho = new Person(123456859, "Gosho1");
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(SecondGosho);
            });
        }

        [Test]
        public void AddShouldThrowExeptionIfCountIs16()
        {
            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, "SomeName" + i));
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(this.Pesho);
            });
        }

        [Test]
        public void RemoveShouldThrowExeptionIfDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            });
        }

        [Test]
        public void RemoveShouldDecreseCount()
        {
            this.db.Add(Pesho);
            this.db.Add(Gosho);
            int expectedCount = db.Count - 1;

            db.Remove();

            Assert.That(db.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void FindByUsernameShouldThrowExeptionIfNoUserWithUsername()
        {
            this.db.Add(Pesho);
            var notExistingName = "Simo";

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername(notExistingName);
            });
        }

        [Test]
        public void FindByUsernameShouldThrowExeptionIfNullIsPassed()
        {
            this.db.Add(Pesho);

            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(null);
            });
        }

        [Test]
        public void FindByUsernameShouldReturnPersonWithThatName()
        {
            this.db.Add(Pesho);
            var pesho = db.FindByUsername("Pesho");

            Assert.That(pesho.UserName, Is.EqualTo("Pesho"));
        }

        [Test]
        public void FindByIdShouldThorowExeptionIfNoUserWithId()
        {
            this.db.Add(Pesho);
            var id = 123456700;

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(id);
            });
        }

        [Test]
        public void FindByIdShouldThorowExeptionIfIdIsNegative()
        {
            this.db.Add(Pesho);
            var id = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(id);
            });
        }

        [Test]
        public void FindByIdShouldReturnPersonWithThatId()
        {
            this.db.Add(Pesho);
            var id = 123456789;
            var person = this.db.FindById(id);
            Assert.That(person.Id, Is.EqualTo(id));
        }
    }
}