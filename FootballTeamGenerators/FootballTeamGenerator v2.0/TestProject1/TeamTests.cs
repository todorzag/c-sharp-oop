using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Team team = CreateTeam();

            Assert.AreEqual(mockTeamName, team.Name);
        }

        [TestMethod()]
        public void SetTeamName_NameIsEmpty_ThrowArgumentExeption()
        {
            string name = " ";

            Action createTeam = () => new Team(name);

            Assert.ThrowsException<ArgumentException>(createTeam);
        }

        [TestMethod()]
        public void SetTeamName_NameIsNull_ThrowArgumentExeption()
        {
            string name = null;

            Action createTeam = () => new Team(name);

            Assert.ThrowsException<ArgumentException>(createTeam);
        }

        [TestMethod()]
        public void AddPlayer_PlayerIsValid_PlayerIsAddedToTeam()
        {
            Team team = CreateTeam();
            Player player = CreatePlayer();

            team.AddPlayer(player);

            Assert.AreEqual(1, team.PlayerCount);
        }

        [TestMethod()]
        public void RemovePlayer_PlayerIsValid_PlayerRemovedFromTeam()
        {
            Team team = CreateTeam();
            Player player = CreatePlayer();

            team.AddPlayer(player);
            team.RemovePlayer(mockPlayerName);

            Assert.AreEqual(0, team.PlayerCount);
        }

        [TestMethod()]
        public void GetTeamRating_EverythingIsValid_ReturnAverageOfPlayerOveralls()
        {
            Team team = CreateTeam();
            Player player1 = CreatePlayer();
            Player player2 = CreatePlayer();

            team.AddPlayer(player1);
            team.AddPlayer(player2);

            // Average of player overalls
            decimal expected = Math.Ceiling((player1.Overall + player2.Overall) / 2);

            Assert.AreEqual(expected, team.Rating);
        }

        [TestMethod()]
        public void CheckIfPlayerInTeam_PlayerIsInTeam_ReturnTrue()
        {
            Team team = CreateTeam();
            Player player = CreatePlayer();

            team.AddPlayer(player);

            bool hasPlayer = team.HasPlayer(mockPlayerName, mockTeamName);

            Assert.IsTrue(hasPlayer);
        }

        [TestMethod()]
        public void CheckIfPlayerInTeam_PlayerIsNotInTeam_ReturnFalse()
        {
            Team team = CreateTeam();

            bool hasPlayer = team.HasPlayer(mockPlayerName, mockTeamName);

            Assert.IsFalse(hasPlayer);
        }

    }
}