using System;
using System.Text;
using System.Collections.Generic;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Age = age;
            this.Name = name;
            this.Id = id;
            this.Birthdate = birthdate;
        }
    }
}
