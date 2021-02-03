using NUnit.Framework;
using System;

namespace Tests
{
    //using ExtendedDatabase;
    public class ExtendedDatabaseTests
    {
        private Person Pesho;
        private Person SecondPesho;
        private Person Gosho;
        private Person SecondGosho;
        private Person[] people;
        private ExtendedDatabase db;

        [SetUp]
        public void Setup()
        {
            this.Pesho = new Person(123456789, "Pesho");
            this.SecondPesho = new Person(123456781, "Pesho");
            this.Gosho = new Person(123456859, "Gosho");
            this.SecondGosho = new Person(123456859, "Gosho1");
            this.db = new ExtendedDatabase();
        }


        //[Test]
        //public void ConstrunctorShouldThrowExeptionIfMoreThan16Lenght()
        //{
        //    this.people = new Person[17];
        //    for (int i = 0; i < 17; i++)
        //    {
        //        this.people[i] = new Person(i, "SomeName" + i);
        //    }

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        this.db = new ExtendedDatabase(this.people);
        //    });
        //}

        //[Test]
        //public void ConstrunctorShouldIncreaseCount()
        //{
        //    this.db = new ExtendedDatabase(this.Pesho, this.Gosho);
        //    Assert.That(this.db.Count, Is.EqualTo(2));
        //}

        [Test]
        public void PersonConstructorShouldSetId() 
        {
            var person = new Person(111, "Simo");
            Assert.That(person.Id, Is.EqualTo(111));            
        }

        [Test]
        public void PersonConstructorShouldSetUsername()
        {
            var person = new Person(111, "Simo");
            Assert.That(person.UserName, Is.EqualTo("Simo"));
        }


        [Test]
        public void AddShouldThrowExeptionIfPersonWithUsernameAlreadyExist()
        {
            this.db.Add(this.Pesho);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(this.SecondPesho);
            });
        }

        [Test]
        public void AddShouldThrowExeptionIfPersonWithIdAlreadyExist()
        {
            this.db.Add(this.Gosho);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(this.SecondGosho);
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






    }
}