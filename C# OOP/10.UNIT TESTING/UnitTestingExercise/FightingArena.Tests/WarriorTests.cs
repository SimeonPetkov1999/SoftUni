
using NUnit.Framework;
using System;

namespace Tests
{
    using FightingArena;

    public class WarriorTests
    {
        private Warrior warrior;
        private Warrior weakWarior;
        private Warrior strongWarior;

        private const string Name = "Simo";
        private const int Damage = 10;
        private const int HP = 80;
        
        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(Name, Damage, HP);
            this.weakWarior = new Warrior("Ivan", 5, 31);
            this.strongWarior = new Warrior("Gosho", 100,200);
        }

        [Test]
        public void ConstructorShouldSetAllValues()
        {
            Assert.That(this.warrior.Name, Is.EqualTo(Name));
            Assert.That(this.warrior.Damage, Is.EqualTo(Damage));
            Assert.That(this.warrior.HP, Is.EqualTo(HP));
        }

        [TestCase(null,Damage,HP)]
        [TestCase("",Damage,HP)]
        [TestCase(" ",Damage,HP)]
        [TestCase(Name,0,HP)]
        [TestCase(Name,-1,HP)]
        [TestCase(Name,Damage,-1)]
        public void ConstructorShouldThrowExeptionIfOneOfParamsIsInvalid(string name,int damage,int hp) 
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.warrior = new Warrior(name, damage, hp);
            });
        }

        [TestCase(25)]
        [TestCase(20)]
        public void AttackShouldThrowExpetionIfHPIsBelow30(int hp) 
        {
            this.warrior = new Warrior(Name, Damage, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.warrior.Attack(this.weakWarior);
            });
        }

        [Test]
        public void AttackShouldThrowExpetionIfTryingToAttackWariorWithHPBelow30()
        {
            this.weakWarior = new Warrior("Ivan", 5, 25); 

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.warrior.Attack(this.weakWarior);
            });
        }

        [Test]
        public void AttackShouldThrowExpetionIfTryingToAttackStrongerWarior()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.warrior.Attack(this.strongWarior);
            });
        }

        [Test]
        public void AttackShouldDecreaseWariorHP()
        {
            var expectedWariorHp = this.warrior.HP - this.weakWarior.Damage;
            this.warrior.Attack(this.weakWarior);
            Assert.That(this.warrior.HP, Is.EqualTo(expectedWariorHp));
        }




    }
}