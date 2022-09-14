using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Items
{
    internal class Repair : IRepair
    {
        public string PartName { get; }
        public int HoursWorked { get; }

        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return $" Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
