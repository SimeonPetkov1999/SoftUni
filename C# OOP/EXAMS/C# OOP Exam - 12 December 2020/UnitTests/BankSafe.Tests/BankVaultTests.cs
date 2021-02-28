using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            this.vault = new BankVault();
            this.item = new Item("Simo","1");
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(vault.VaultCells.Count, Is.EqualTo(12));
        }

        [Test]
        public void AddItemToNotExistingCellShouldThrowExeption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("NotExestingCell",item);
            });
        }

        [Test]
        public void AddItemToTakenCellShouldThrowExeption()
        {
            vault.AddItem("A1", new Item("Test", "Test"));
            Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("Al", item);
            });
        }

        [Test]
        public void AddItemTwiceShouldThrowExeption()
        {     
            Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A2", new Item("Test", "Test"));
                vault.AddItem("A1", new Item("Test", "Test"));
            });
        }

        [Test]
        public void AddItemWorking()
        {
            vault.AddItem("A1",item);
            Assert.That(vault.VaultCells["A1"], Is.EqualTo(item));
        
        }
        [Test]
        public void RemoveItemShouldThrowExeptionIfCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("NotExestingCell", item);
            });
        }

        [Test]
        public void RemoveItemShouldThrowExeptionIfItemIsoNotinTheCell()
        {
            vault.AddItem("A1", item);
            vault.AddItem("A2", new Item("Test","Test"));
            Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A2", item);
            });
        }

        [Test]
        public void RemoveItemWorking()
        {
            vault.AddItem("A1", item);
            vault.RemoveItem("A1", item);
            Assert.That(vault.VaultCells["A1"], Is.EqualTo(null));
        }





    }
}