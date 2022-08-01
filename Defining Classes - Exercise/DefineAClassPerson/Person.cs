using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineAClassPerson
{
    internal class Person
    {
        private string name;
        private int age;

        public string Name { get { return name; } set { this.name = value; } }

        public int Age { get { return age; } set { this.age = value; } }

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
