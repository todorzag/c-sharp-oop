using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpinionPoll
{
    internal class Person
    {
<<<<<<< HEAD
        public string Name { get; }
        public int Age { get; }
=======
        public string Name { get; set; }

        public int Age { get; set; }
>>>>>>> master

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age) : this()
        {
            Age = age;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} - {Age} ";
        }
    }
}
