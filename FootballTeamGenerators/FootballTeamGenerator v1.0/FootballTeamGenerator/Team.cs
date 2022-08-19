using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string _name;
        private List<Player> _players = new List<Player>();

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
        public decimal Rating 
        {
            get => CalculateRating();
        }

        public int PlayersCount
        {
            get => _players.Count;
        }

        public Team(string name)
        {
            Name = name;
        }

        public void AddPlayer(Player player) =>
            _players.Add(player);


        public void RemovePlayerByName(string playerName) => 
            _players.Remove(_players.Find(player => player.Name == playerName));

        public void CheckIfPlayerInTeam(string playerName, string teamName)
        {
            bool notInTeam = _players.Find(player => player.Name == playerName) == null;

            if (notInTeam)
            {
                throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
            }
        }

        private decimal CalculateRating() => 
            Math.Ceiling(_players.Average(player => player.Overall));

    }
}
