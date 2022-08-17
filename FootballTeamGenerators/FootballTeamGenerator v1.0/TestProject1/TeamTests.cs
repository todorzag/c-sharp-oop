using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballTeamGenerator.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.UnitTests
{
    [TestClass()]
    public class TeamTests
    {
        public static string mockTeamName = "Spartak Shturkovo";

        public static List<IStat> mockStats = new List<IStat>
            {
                new Endurance(12),
                new Sprint(22),
                new Dribble(53),
                new Passing(43),
                new Shooting(3)
            };

        public static string mockPlayerName = "Kircho";

        [TestMethod()]
        public void SetTeamName_NameIsValid_TeamNameIsSet()
        {
            Team team = new Team(mockTeamName);

            Assert.AreEqual(mockTeamName, team.Name);
        }

        [TestMethod()]
        public void SetTeamName_NameIsEmpty_ThrowArgumentExeption()
        {
            string name = " ";

            Action createTeam = () =>
            {
                Team team = new Team(name);
            };

            Assert.ThrowsException<ArgumentException>(createTeam);
        }

        [TestMethod()]
        public void SetTeamName_NameIsNull_ThrowArgumentExeption()
        {
            string name = null;

            Action createTeam = () =>
            {
                Team team = new Team(name);
            };

            Assert.ThrowsException<ArgumentException>(createTeam);
        }

        [TestMethod()]
        public void AddPlayer_PlayerIsValid_PlayerIsAdded()
        {
            Team team = new Team(mockTeamName);
            Player player = new Player(mockPlayerName, mockStats);

            team.AddPlayer(player);

            Assert.AreEqual(1, team.PlayersCount);
        }

        [TestMethod()]
        public void RemovePlayer_PlayerIsValid_PlayerIsRemoved()
        {
            Team team = new Team(mockTeamName);
            Player player = new Player(mockPlayerName, mockStats);

            team.AddPlayer(player);
            team.RemovePlayerByName(mockPlayerName);

            Assert.AreEqual(0, team.PlayersCount);
        }

        [TestMethod()]
        public void GetTeamRating_EverythingIsValid_ReturnAverageOfPlayerOveralls()
        {
            Team team = new Team(mockTeamName);
            Player player1 = new Player("Ronaldo", mockStats);
            Player player2 = new Player("Messi", mockStats);

            team.AddPlayer(player1);
            team.AddPlayer(player2);

            // Average of player overalls
            decimal expected = (player1.Overall + player2.Overall) / team.PlayersCount;

            Assert.AreEqual(expected, team.Rating);
        }

        [TestMethod()]
        public void CheckIfPlayerInTeam_PlayerInTeam_ReturnTrue()
        {
            Team team = new Team(mockTeamName);
            Player player = new Player(mockPlayerName, mockStats);

            team.AddPlayer(player);

            bool isInTeam = team.CheckIfPlayerInTeam(mockPlayerName);
            Assert.IsTrue(isInTeam);
        }

        [TestMethod()]
        public void CheckIfPlayerInTeam_PlayerIsNotInTeam_ReturnFalse()
        {
            Team team = new Team(mockTeamName);
            Player player = new Player(mockPlayerName, mockStats);
            string notInTeam = "Ronaldo";

            team.AddPlayer(player);

            bool isInTeam = team.CheckIfPlayerInTeam(notInTeam);
            Assert.IsFalse(isInTeam);
        }
    }
}