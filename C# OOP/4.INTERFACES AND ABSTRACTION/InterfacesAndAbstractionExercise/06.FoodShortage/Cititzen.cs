using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    class Cititzen : IID , IBirthable,IBuyer
    {
        public Cititzen(string name,int age,string id,string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.BirthDate = birthDate;
            this.Food = 0;
        }
        public string Name { get; private set; }
        public int Age { get; set; }
        public string ID {get; private set; }
        public string BirthDate { get; private set; }
        public string BirthYear => this.BirthDate.Substring(this.BirthDate.Length - 4);
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
