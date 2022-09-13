using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private static List<string> ValidCorps = 
            new List<string> 
            { 
                "Airforce",
                "Marines"
            };

        private string _corps;

        public string Corps 
        { 
            get { return _corps; }

            init
            {
                if (isValidCorp(value))
                {
                    _corps = value;
                }

                throw new ArgumentException("Corps is invalid!");
            }
        }

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        private bool isValidCorp(string corp)
        {
            return ValidCorps.Contains(corp);
        }
    }
}
