using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    internal class Engineer : SpecialisedSoldier
    {
        public List<Repair> Repairs { get; }

        public Engineer
            (int id, string firstName, string lastName, decimal salary, string corps, List<Repair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public override string ToString()
        {
            return BasicInfo +
                $"\nCorps: {Corps}" +
                $"\nRepairs:" +
                $"\n{PrintRepairs()}";
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
