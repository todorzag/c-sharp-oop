using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Soldiers
{
    public abstract class Soldier : ISoldier
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        protected Soldier(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
