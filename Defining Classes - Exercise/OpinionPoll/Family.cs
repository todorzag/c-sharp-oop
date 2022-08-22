using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpinionPoll
{
    internal class Family
    {
        private List<Person> People { get; }

        public Family()
        {
            People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            return People.OrderByDescending(m => m.Age).ToArray()[0];
        }

        public List<Person> GetAllPeopleOver30()
        {
            return People.Where(person => person.Age >= 30).ToList();
        }
    }
}
