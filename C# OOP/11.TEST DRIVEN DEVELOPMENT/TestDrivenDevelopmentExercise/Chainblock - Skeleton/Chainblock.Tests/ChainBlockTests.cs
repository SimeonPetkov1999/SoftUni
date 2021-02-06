using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainBlockTests
    {
        private ChainBlock block;
        private Transaction transaction;
        private int id = 1;
        private TransactionStatus ts = (TransactionStatus)1;
        private string from = "Simo";
        private string to = "Pesho";
        private double amount = 10;

        [SetUp]
        public void SetUp()
        {
            this.block = new ChainBlock();
            this.transaction = new Transaction(this.id, this.ts, this.from, this.to, this.amount);
        }

        //Constructor 
        [Test]
        public void ConstructorShouldSetTransactionTo0()
        {
            Assert.That(this.block.Count, Is.EqualTo(0));
        }

        //Contains 
        [Test]
        public void ContainsShouldReturnTrueIfTheIdIsPresent()
        {
            this.block.Add(this.transaction);
            Assert.IsTrue(block.Contains(1));
        }

        [Test]
        public void ContainsShouldReturnFalseIfTheIdIsPresent()
        {
            this.block.Add(this.transaction);
            Assert.IsFalse(block.Contains(2));
        }

        //Add  
        [Test]
        public void AddShouldIncreaseCount()
        {
            var anotherTransaction = new Transaction(this.id + 1, this.ts, this.from, this.to, this.amount);

            this.block.Add(this.transaction);
            this.block.Add(anotherTransaction);
            Assert.That(block.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddShouldThorowExeptionIfIdIsPresent()
        {
            this.block.Add(this.transaction);
            Assert.Throws<ArgumentException>(() =>
            {
                this.block.Add(this.transaction);
            }, "Invalid Id");
        }

        //ChangeTransactionStatus 
        [Test]
        public void ChangeTransactionStatusShouldSetNewStatus()
        {
            this.block.Add(this.transaction);

            this.block.ChangeTransactionStatus(this.id, TransactionStatus.Failed);

            Assert.That(this.transaction.Status, Is.EqualTo(TransactionStatus.Failed));
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowExeptionIfTransactionDoesNotExists()
        {
            this.block.Add(this.transaction);

            Assert.Throws<ArgumentException>(() =>
            {
                this.block.ChangeTransactionStatus(5, TransactionStatus.Failed);
            }, "Id is not in the block");
        }

        //GetById 
        [Test]
        public void GetByIdShouldReturnTransaction()
        {
            this.block.Add(this.transaction);

            var returnedTransaction = this.block.GetById(this.id);

            Assert.That(returnedTransaction, Is.EqualTo(this.transaction));
        }

        [Test]
        public void GetByIdShouldThrowExeptionIfIdIsNotInTheBlock()
        {
            this.block.Add(this.transaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.block.GetById(2);
            }, "Id is not in the block");
        }

        //RemoveTransactionById
        [Test]
        public void RemoveTransactionByIdShouldDecreseCountIfRemovedSuccesfuly()
        {
            this.block.Add(this.transaction);
            this.block.Add(new Transaction(5, this.ts, this.from, this.to, this.amount));

            this.block.RemoveTransactionById(5);
            var expectedCount = 1;

            Assert.That(this.block.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowExeptionIfIdIsNotInTheBlock()
        {
            this.block.Add(this.transaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.block.RemoveTransactionById(5);
            }, "Id is not in the block");
        }

        //GetByTransactionStatus
        [Test]
        public void GetByTransactionStatusShouldReturnListOfTransactionOrderedByAmount()
        {
            var secondTransaction = new Transaction(5, TransactionStatus.Successfull, "Ivan", "Petkan", 500);
            var thirdTransaction = new Transaction(6, TransactionStatus.Aborted, "Ivan", "John", 1000);
            var forthTransaction = new Transaction(7, TransactionStatus.Successfull, "Ivan", "Simo", 200);
            var expectedOrderedList = new List<ITransaction>()
            {
                this.transaction,
                secondTransaction,
                thirdTransaction,
                forthTransaction
            };

            expectedOrderedList = expectedOrderedList
                .Where(t => t.Status == TransactionStatus.Successfull)
                .OrderByDescending(t => t.Amount)
                .ToList();

            this.block.Add(this.transaction);
            this.block.Add(secondTransaction);
            this.block.Add(thirdTransaction);
            this.block.Add(forthTransaction);

            var returnedTransaction = this.block.GetByTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedOrderedList, returnedTransaction);
        }
        [Test]
        public void GetByTransactionStatusShouldThrowExeptionIfThereIsNoTransactionWithGiveStatus()
        {
            var secondTransaction = new Transaction(5, TransactionStatus.Successfull, "Ivan", "Petkan", 500);
            var thirdTransaction = new Transaction(6, TransactionStatus.Aborted, "Ivan", "John", 1000);
            var forthTransaction = new Transaction(7, TransactionStatus.Successfull, "Ivan", "Simo", 200);

            this.block.Add(this.transaction);
            this.block.Add(secondTransaction);
            this.block.Add(thirdTransaction);
            this.block.Add(forthTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.block.GetByTransactionStatus(TransactionStatus.Failed);
            }, "No Transactions with given Status");
        }

        //GetAllSendersWithTransactionStatus
        [Test]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Aborted)]
        public void GetAllSendersWithTransactionStatusShouldReturnCollectionWithPersonsNames(TransactionStatus status)
        {
            var secondTransaction = new Transaction(5, TransactionStatus.Successfull, "Ivan", "Petkan", 15);
            var thirdTransaction = new Transaction(6, TransactionStatus.Aborted, "Gosho", "John", 10);
            var forthTransaction = new Transaction(7, TransactionStatus.Successfull, "Martin", "Simo", 50000);

            var list = new List<ITransaction>()
            {
                this.transaction,
                secondTransaction,
                thirdTransaction,
                forthTransaction
            };

            var expectedOrderedList = list
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            this.block.Add(this.transaction);
            this.block.Add(secondTransaction);
            this.block.Add(thirdTransaction);
            this.block.Add(forthTransaction);

            var returnedCollection = this.block.GetAllSendersWithTransactionStatus(status);

            CollectionAssert.AreEqual(expectedOrderedList, returnedCollection);
        }

        [Test]
        [TestCase(TransactionStatus.Failed)]
        public void GetAllSendersWithTransactionStatusShouldThrowExeptionIfNoTansactionExist(TransactionStatus status)
        {
            var secondTransaction = new Transaction(5, TransactionStatus.Successfull, "Ivan", "Petkan", 15);
            var thirdTransaction = new Transaction(6, TransactionStatus.Aborted, "Gosho", "John", 10);
            var forthTransaction = new Transaction(7, TransactionStatus.Successfull, "Martin", "Simo", 50000);

            this.block.Add(this.transaction);
            this.block.Add(secondTransaction);
            this.block.Add(thirdTransaction);
            this.block.Add(forthTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.block.GetAllSendersWithTransactionStatus(status);
            }, "No Transactions with given Status");
        }

        //GetAllRecieversWithTransactionStatus
        [Test]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Aborted)]
        public void GetAllRecieversWithTransactionStatusShouldReturnCollectionWithPersonsNames(TransactionStatus status) 
        {
            var secondTransaction = new Transaction(5, TransactionStatus.Successfull, "Ivan", "Petkan", 15);
            var thirdTransaction = new Transaction(6, TransactionStatus.Aborted, "Gosho", "John", 10);
            var forthTransaction = new Transaction(7, TransactionStatus.Successfull, "Martin", "Simo", 50000);

            var list = new List<ITransaction>()
            {
                this.transaction,
                secondTransaction,
                thirdTransaction,
                forthTransaction
            };

            var expectedOrderedList = list
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To)
                .ToList();

            this.block.Add(this.transaction);
            this.block.Add(secondTransaction);
            this.block.Add(thirdTransaction);
            this.block.Add(forthTransaction);

            var returnedCollection = this.block.GetAllReceiversWithTransactionStatus(status);

            CollectionAssert.AreEqual(expectedOrderedList, returnedCollection);
        }

        [Test]
        [TestCase(TransactionStatus.Failed)]
        public void GetAllRecieversWithTransactionStatusShouldThrowExeptionIfNoTansactionExist(TransactionStatus status)
        {
            var secondTransaction = new Transaction(5, TransactionStatus.Successfull, "Ivan", "Petkan", 15);
            var thirdTransaction = new Transaction(6, TransactionStatus.Aborted, "Gosho", "John", 10);
            var forthTransaction = new Transaction(7, TransactionStatus.Successfull, "Martin", "Simo", 50000);

            this.block.Add(this.transaction);
            this.block.Add(secondTransaction);
            this.block.Add(thirdTransaction);
            this.block.Add(forthTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.block.GetAllReceiversWithTransactionStatus(status);
            }, "No Transactions with given Status");
        }
    }
}
