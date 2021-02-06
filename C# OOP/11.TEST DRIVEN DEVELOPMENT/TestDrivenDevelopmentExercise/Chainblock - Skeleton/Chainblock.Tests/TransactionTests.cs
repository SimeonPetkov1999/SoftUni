using NUnit.Framework;

namespace Chainblock.Tests
{

    using Chainblock;
    using System;

    [TestFixture]
    class TransactionTests
    {
        private int id = 1;
        private TransactionStatus ts = (TransactionStatus)1;
        private string from = "Simo";
        private string to = "Pesho";
        private double amount = 10;
        [Test]
        public void ConstructorShouldSetAllValues()
        {
            var transaction = new Transaction(id, ts, from, to, amount);
            Assert.That(transaction.Id, Is.EqualTo(1));
            Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.Successfull));
            Assert.That(transaction.From, Is.EqualTo("Simo"));
            Assert.That(transaction.To, Is.EqualTo("Pesho"));
            Assert.That(transaction.Amount, Is.EqualTo(10));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void IdShouldThorowExceptionIfIsZeroOrNegative(int id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Transaction(id, this.ts, this.from, this.to, this.amount);
            }, "Id must be positive number");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void FromShouldThorowExceptionIfIsNullEmptyOrWhiteSpace(string from)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Transaction(this.id, this.ts, from, this.to, this.amount);
            }, "Invalid sender name");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void ToShouldThorowExceptionIfIsNullEmptyOrWhiteSpace(string to)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Transaction(this.id, this.ts, this.from, to, this.amount);
            }, "Invalid reciever name");
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void AmountShouldThorowExceptionIfIsZeroOrNegative(int amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Transaction(this.id, this.ts, this.from, this.to, amount);
            }, "Amount must be positive number");
        }
    }
}
