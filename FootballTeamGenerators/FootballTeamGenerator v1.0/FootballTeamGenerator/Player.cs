using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string _name;
        private List<IStat> _stats;

        public string Name
        {
            get => _name;

            init
            {
                if (value == " " || value == null)
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                _name = value;
            }
        }

        public List<IStat> Stats
        {
            get => _stats;

            init
            {
                foreach (var stat in value)
                {
                    bool notInRange = stat.Value < 0 || stat.Value > 100;

                    if (notInRange)
                    {
                        Console.WriteLine($"{stat.Name} should be between 0 and 100.");
                        stat.Value = 0;
                    }
                }

                _stats = value;
            }
        }

        public decimal Overall
        {
            get => CalculateOverall();
        }

        public Player(string name, List<IStat> stats)
        {
            Name = name;
            Stats = stats;
        }

        private decimal CalculateOverall() => 
            Math.Ceiling((decimal)Stats.Average(x => x.Value));
    }
}
