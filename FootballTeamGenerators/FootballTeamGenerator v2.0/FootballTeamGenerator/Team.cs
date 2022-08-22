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
            init => _name = ValidateNameThrowException(value);
        }

        public decimal Rating
        {
            get => CalculateRating();
        }

        public int PlayerCount 
        { 
            get => _players.Count();
        } 

        public Team(string name)
        {
            Name = name;
        }

        public void AddPlayer(Player player) => 
            _players.Add(player);
 

        public void RemovePlayer(string playerName) => 
            _players.Remove(_players.Find(player => player.Name == playerName));
        

        public bool HasPlayer(string playerName, string teamName) => 
            _players.Find(x => x.Name == playerName) != null;


        private decimal CalculateRating() =>
            Math.Ceiling(_players.Average(player => player.Overall));

        private string ValidateNameThrowException(string name)
        {
            bool isEmptyOrNull = name == " " || name == null;

            if (isEmptyOrNull)
            {
                throw new ArgumentException("A name should not be empty.");
            }

            return name;
        }
    }
}
