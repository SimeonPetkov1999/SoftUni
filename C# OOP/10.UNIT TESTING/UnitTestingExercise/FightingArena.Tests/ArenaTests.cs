using NUnit.Framework;
using System; 
namespace Tests
{
    using FightingArena;
    public class ArenaTests
    {
        private const string Name = "Ivan";
        private const int Damage = 50;
        private const int HP = 100;
        private Arena arena;
        private Warrior firstWarrior;
        private Warrior secondWarrior;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ConstructorTestCount()
        {
            this.arena = new Arena();
            Assert.That(this.arena.Count,Is.EqualTo(0));
        }
        [Test]
        public void EnrolCountShouldBe0()
        {
            Assert.That(this.arena.Count,Is.EqualTo(0));
        }
        [Test]
        public void EnrolWarriorCountShouldBe0()
        {
            Assert.That(this.arena.Warriors.Count,Is.EqualTo(0));
        }
        [Test]
        public void EnrollMethodInvalidArgs()
        {
            this.firstWarrior = new Warrior(Name, Damage, HP);
            this.arena.Enroll(this.firstWarrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(new Warrior("Ivan", 10, 20));
            });
        }

        [Test]
        public void EnrollCorrectNameCheck()
        {
            this.firstWarrior = new Warrior(Name, Damage, HP);
            Warrior expectedNameResult = firstWarrior;
            this.arena.Enroll(this.firstWarrior);
            Assert.That(firstWarrior.Name, Is.EqualTo(expectedNameResult.Name));
        }

        [Test]
        public void EnrollCorect()
        {
            this.firstWarrior = new Warrior(Name, Damage, HP);
            int expectedResult = this.arena.Count + 1;
            this.arena.Enroll(this.firstWarrior);
            Assert.That(this.arena.Count,Is.EqualTo(expectedResult));
        }
       
        [Test]
        [TestCase("Ivan", "Pater")]
        [TestCase("Petko", "Martin")]
        public void FightMethodShouldThrowExeptionIFWariorDontExist(string attackName, string defendName)
        {
            this.firstWarrior = new Warrior(Name, Damage, HP);
            this.arena.Enroll(this.firstWarrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attackName, defendName);
            });
        }
        [Test]
        [TestCase(Name, "Petar")]
        public void FightValid(string attackName, string defendName)
        {
            this.firstWarrior = new Warrior(Name, Damage, HP);
            this.secondWarrior = new Warrior("Petar", 60, 80);

            this.arena.Enroll(this.firstWarrior);
            this.arena.Enroll(this.secondWarrior);

            int expectedResult = this.firstWarrior.HP - this.secondWarrior.Damage;
            this.arena.Fight(attackName, defendName);
            Assert.That(this.firstWarrior.HP,Is.EqualTo(expectedResult));
        }
    }
}
