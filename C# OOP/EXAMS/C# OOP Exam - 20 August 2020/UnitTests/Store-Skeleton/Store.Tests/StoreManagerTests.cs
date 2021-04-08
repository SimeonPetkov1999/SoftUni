using NUnit.Framework;
using System;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ContructorTest()
        {
            var manager = new StoreManager();
            Assert.That(manager.Count, Is.EqualTo(0));
            Assert.That(manager.Products.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddProductShouldThrowExeptionOfProductIsNull()
        {
            var manager = new StoreManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.AddProduct(null);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void AddProductShouldThrowExeptionOfProductQuantityisNegative(int quantity)
        {
            var manager = new StoreManager();

            Assert.Throws<ArgumentException>(() =>
            {
                manager.AddProduct(new Product("Test", quantity, 4));
            });
        }

        [Test]
        public void AddProductWorkingFine()
        {
            var manager = new StoreManager();
            manager.AddProduct(new Product("Test", 50, 10));
            manager.AddProduct(new Product("Test1", 40, 5));
            Assert.That(manager.Count, Is.EqualTo(2));
          
        }

        [Test]
        public void BuyProductShouldThrowExeptionIfProductDoesNotExist()
        {
            var manager = new StoreManager();
            manager.AddProduct(new Product("Test", 50, 10));
            manager.AddProduct(new Product("Test1", 50, 20));

            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.BuyProduct("NotExistingProduct",10);
            });

        }

        [Test]
        public void BuyProductShouldThrowExeptionIfProductQuantityNotEnough()
        {
            var manager = new StoreManager();
            manager.AddProduct(new Product("Test", 50, 10));
            manager.AddProduct(new Product("Test1", 50, 20));

            Assert.Throws<ArgumentException>(() =>
            {
                manager.BuyProduct("Test", 100);
            });
        }

        [Test]
        public void BuyProductWorkingFine()
        {
            var manager = new StoreManager();
            var product = new Product("Test", 10, 10);
            var product1 = new Product("Test1", 50, 10);

            manager.AddProduct(product);
            manager.AddProduct(product1);

            manager.BuyProduct("Test", 5);

            Assert.That(product.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void GetMostExpensiveProductTest()
        {
            var manager = new StoreManager();
            var product = new Product("Test", 10, 100);
            var product1 = new Product("Test1", 50, 5);

            manager.AddProduct(product);
            manager.AddProduct(product1);

            Assert.That(manager.GetTheMostExpensiveProduct(), Is.EqualTo(product));
        }


    }
}