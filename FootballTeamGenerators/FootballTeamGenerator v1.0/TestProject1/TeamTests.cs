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
    public class TeamTests : TestData
    {
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

            Action createTeam = () => CreateTeam(name);

            Assert.ThrowsException<ArgumentException>(createTeam);
        }

        [TestMethod()]
        public void SetTeamName_NameIsNull_ThrowArgumentExeption()
        {
            string name = null;

            Action createTeam = () => CreateTeam(name);

            Assert.ThrowsException<ArgumentException>(createTeam);
        }

        [TestMethod()]
        public void AddPlayer_PlayerIsValid_PlayerIsAdded()
        {
            Team team = CreateTeam();
            Player player = CreatePlayer();

            team.AddPlayer(player);

            Assert.AreEqual(1, team.PlayersCount);
        }

        [TestMethod()]
        public void RemovePlayer_PlayerIsValid_PlayerIsRemoved()
        {
            Team team = CreateTeam();
            Player player = CreatePlayer();

            team.AddPlayer(player);
            team.RemovePlayerByName(mockPlayerName);

            Assert.AreEqual(0, team.PlayersCount);
        }

        [TestMethod()]
        public void GetTeamRating_EverythingIsValid_ReturnAverageOfPlayerOveralls()
        {
            Team team = CreateTeam();
            Player player1 = CreatePlayer("Ronaldo");
            Player player2 = CreatePlayer("Messi");

            team.AddPlayer(player1);
            team.AddPlayer(player2);

            // Average of player overalls
            decimal expected = (player1.Overall + player2.Overall) / team.PlayersCount;

            Assert.AreEqual(expected, team.Rating);
        }

        [TestMethod()]
        public void CheckIfPlayerInTeam_PlayerIsNotInTeam_ThrowArgumentError()
        {
            Team team = CreateTeam();
            Player player = CreatePlayer();
            string notInTeam = "Ronaldo";

            team.AddPlayer(player);

            Action CheckPlayer = () =>
            team.CheckIfPlayerInTeam(notInTeam, mockTeamName);

            Assert.ThrowsException<ArgumentException>(CheckPlayer);
        }
    }
}