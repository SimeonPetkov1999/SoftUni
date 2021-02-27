using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> FoodOrders;
        private List<IDrink> DrinkOrders;

        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.FoodOrders = new List<IBakedFood>();
            this.DrinkOrders = new List<IDrink>();
        }
        public int TableNumber
        {
            get => this.tableNumber;
            private set
            {
                this.tableNumber = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get => this.pricePerPerson;
            private set
            {
                this.pricePerPerson = value;
            }
        }

        public bool IsReserved
        {
            get => this.isReserved;
            private set 
            {
                this.isReserved = value;
            }
        }

        public decimal Price 
        {
            get => this.GetBill(); /// this.NumberOfPeople;//?
        }

        public void Clear()//?
        {
            this.FoodOrders.Clear();
            this.DrinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            var foodPrice = 0m;
            foreach (var food in this.FoodOrders)
            {
                foodPrice += food.Price;
            }

            var drinkPrice = 0m;
            foreach (var drink in this.DrinkOrders)
            {
                drinkPrice += drink.Price;
            }

            return drinkPrice + foodPrice;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Price per Person: {this.pricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
