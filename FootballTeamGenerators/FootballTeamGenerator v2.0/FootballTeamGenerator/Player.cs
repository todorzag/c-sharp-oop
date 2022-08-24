using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
        private static int _statCount = 5;

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
                ValidateNameThrowException(value);
                _name = value;
            }
        }

        public int Endurance
        {
            get => _endurance;
            init
            {
                ValidateStatThrowException(value, nameof(Endurance));
                _endurance = value;
            }  
        }

        public int Sprint
        {
            get => _sprint;
            init
            {
                ValidateStatThrowException(value, nameof(Sprint));
                _sprint = value;
            }
        }

        public int Dribble
        {
            get => _dribble;
            init
            {
                ValidateStatThrowException(value, nameof(Dribble));
                _dribble = value;
            }
        }

        public int Passing
        {
            get => _passing;
            init
            {
                ValidateStatThrowException(value, nameof(Passing));
                _passing = value;
            }
        }

        public int Shooting
        {
            get => _shooting;
            init
            {
                ValidateStatThrowException(value, nameof(Shooting));
                _shooting = value;
            }
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

        private decimal CalculateOverall() =>
            (decimal)(_endurance + _sprint + _dribble + _passing + _shooting) / _statCount;

        private void ValidateStatThrowException(int stat, string name)
        {
            bool statNotInRange = stat < 0 || stat > 100;

            if (statNotInRange)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }

        private void ValidateNameThrowException(string name)
        {
            bool isEmptyOrNull = name == " " || name == null;

            if (isEmptyOrNull)
            {
                throw new ArgumentException("A name should not be empty.");
            }
        }
    }
}
