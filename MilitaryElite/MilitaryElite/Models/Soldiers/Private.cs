using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Soldiers
{
    public class Private : Soldier, IPrivate
    {
        public decimal Salary { get; }
        public string BasicInfo
        {
            get => $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary}";
        }

        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return BasicInfo;
        }
    }
}
