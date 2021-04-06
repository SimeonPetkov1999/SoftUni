using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            //?
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth
        {
            get => this.baseHealth;
            private set => this.baseHealth = value;
        }

        public double Health
        {
            get => this.health;
            set
            {
                this.health = value;
                if (this.health<0)
                {
                    this.health = 0;
                }
                else if (this.health>this.BaseHealth)
                {
                    this.health = this.baseHealth;
                }
            }//?
        }

        public double BaseArmor
        {
            get => this.baseArmor;
            private set => this.baseArmor = value;
        }

        public double Armor
        {
            get => this.armor;
            private set
            {
                this.armor = value;

                if (this.armor < 0)
                {
                    this.armor = 0;
                }
            }
        }

        public double AbilityPoints
        {
            get => this.abilityPoints;
            private set => this.abilityPoints = value;
        }

        public Bag Bag
        {
            get => this.bag;
            private set { this.bag = value; }
        }

        //public bool IsAlive => this.Health > 0;//?
        public bool IsAlive { get; set; } = true;


        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (this.Armor - hitPoints >= 0)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health -= hitPoints;
            }

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);//?
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}