using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private ICollection<Employee> data;

        private Bakery() 
        {
            this.data = new List<Employee>();
        }
        public Bakery(string Name, int capacity)
            : this()
        {
            this.Name = Name;
            this.Capacity = capacity;
           
        }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count { get => this.data.Count; }

        public void Add(Employee employee)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(employee);
            }
        }

        public bool Remove(string name) =>
             this.data.Remove(this.data.FirstOrDefault(e => e.Name == name));

        public Employee GetOldestEmployee() => this.data.OrderByDescending(e => e.Age).First();

        public Employee GetEmployee(string name) => this.data.FirstOrDefault(e => e.Name == name);

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in this.data)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
