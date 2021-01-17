using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(){}
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                Validate(value);
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                ValidationForAge(value);
                this.age = value;
            }
        }

        public string Gender
        {
            get { return this.gender; }
            set
            {
                Validate(value);
                this.gender = value;
            }
        }    

        public virtual string ProduceSound()
        {
            return null;
        }

        private static void Validate(string value)
        {
            if (value == null)
            {
                throw new InvalidOperationException("Ivalid input!");
            }
        }

        private void ValidationForAge(int value)
        {
            if (value < 0)
            {
                throw new InvalidOperationException("Ivalid input!");
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(ProduceSound());
            return sb.ToString();
        }
    }
}
