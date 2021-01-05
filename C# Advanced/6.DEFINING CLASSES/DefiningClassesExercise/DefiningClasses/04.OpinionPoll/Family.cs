using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public List<Person> GetPeopleOlderThan30() 
        {
            var people = new List<Person>();
            people = this.People.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();
            return people;
        }
    }
}
