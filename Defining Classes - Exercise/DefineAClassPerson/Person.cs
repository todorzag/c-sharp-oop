using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineAClassPerson
{
    internal class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age) : this()
        {
            Age = age;
        }

        public Person (string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string WhoAmI()
        {
            return $"Hi my name is {Name} and I am {Age} years old";
        }
    }
}
