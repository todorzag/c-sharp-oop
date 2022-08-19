using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
        private static List<string> restrictedProperties =
            new List<string>
            {
                "Name",
                "Overall"
            };

        private string _name;

        private int _endurance;
        private int _sprint;
        private int _dribble;
        private int _passing;
        private int _shooting;


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

        public int Endurance
        {
            get => _endurance;
            set => _endurance = StatHandler(value, nameof(Endurance));  
        }

        public int Sprint
        {
            get => _sprint;
            set => _sprint = StatHandler(value, nameof(Sprint));
        }

        public int Dribble
        {
            get => _dribble;
            set => _dribble = StatHandler(value, nameof(Dribble));
        }

        public int Passing
        {
            get => _passing;
            set => _passing = StatHandler(value, nameof(Passing));
        }

        public int Shooting
        {
            get => _shooting;
            set => _shooting = StatHandler(value, nameof(Shooting));
        }

        public decimal Overall
        {
            get => Math.Ceiling(CalculateOverall());
        }

        public Player(string name, int endurance, int sprint, int dribble, int pasing, int shooting)
        {
            Name = name;

            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = pasing;
            Shooting = shooting;
        }

        private decimal CalculateOverall()
        {
            var properties = GetType()
                    .GetProperties()
                    .Where(prop => !restrictedProperties.Contains(prop.Name))
                    .ToList();

            return properties
                .Average(property => 
                decimal.Parse(property.GetValue(this, null).ToString()));
        }

        private int StatHandler(int stat, string name)
        {
            bool statInRange = stat >= 0 && stat <= 100;

            if (statInRange)
            {
                return stat;
            }
            else
            {
                Console.WriteLine($"{name} should be between 0 and 100.");
                return 0;
            }
        }
    }
}
