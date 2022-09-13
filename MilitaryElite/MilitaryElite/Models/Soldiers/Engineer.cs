using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Interfaces;
using MilitaryElite.Other;

namespace MilitaryElite
{
    internal class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<Repair> Repairs { get; }

        public Engineer
            (int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<Repair>();
        }

        public void AddRepairs(Repair repair)
        {
            Repairs.Add(repair);
        }

        public override string ToString()
        {
            string repairsInfoString = Repairs.Count > 0 ? $"\n{PrintRepairs()}" : string.Empty;

            return BasicInfo +
                $"\nCorps: {Corps}" +
                $"\nRepairs:" +
                repairsInfoString;
        }

        private string PrintRepairs()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Repair repair in Repairs)
            {
                sb.AppendLine(repair.ToString());
            }

            return sb.ToString();
        }
    }
}
