using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    class Person
    {
        private string name;
        private double money;
        private List<string> bag;

        public Person(string name,double money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<string>();
        }

        public string Name 
        {
            get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Money 
        {
            get => this.money;
            private set 
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.money = value;
            } 
        }
        public IReadOnlyCollection<string> Bag => this.bag.AsReadOnly();

        public string AddProduct(Product product) 
        {
            if (PersonHaveEnoughMoney(product))
            {
                this.Money -= product.Cost;
                this.bag.Add(product.Name);
                return $"{this.Name} bought {product.Name}";
            }

            throw new Exception($"{this.Name} can't afford {product.Name}");

        }

        private bool PersonHaveEnoughMoney(Product product)
        {
            if (this.Money-product.Cost>=0)
            {
                return true;
            }
            return false;
        }
    }
}
