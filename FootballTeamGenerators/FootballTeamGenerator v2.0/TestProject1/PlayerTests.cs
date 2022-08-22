using FootballTeamGenerator;

namespace FootballTeamGenerator.UnitTests
{
    [TestClass]
    public class PlayerTests : TestData
    {
        [TestMethod()]
        public void SetName_NameValidString_PlayerNameEqualToName()
        {
            // Normal player
            Player player = CreatePlayer();

            Assert.AreEqual(mockPlayerName, player.Name);
        }

        [TestMethod()]
        public void SetName_NameIsEmpty_ThrowArgumentExeption()
        {
            string name = " ";

            Action createPlayer = () => CreatePlayer(name);

            Assert.ThrowsException<ArgumentException>(createPlayer);
        }

        [TestMethod()]
        public void SetName_NameIsNull_ThrowArgumentExeption()
        {
            string name = null;

            Action createPlayer = () => CreatePlayer(name);

            Assert.ThrowsException<ArgumentException>(createPlayer);
        }

        [TestMethod()]
        public void SetStats_StatsAreInRange_StatsAreSet()
        {
            Player player = CreatePlayer();

            Assert.AreEqual(player.Dribble, mockDribble);
            Assert.AreEqual(player.Shooting, mockShooting);
        }

        [TestMethod()]
        public void SetStats_StatsAreUnder0_ThrowsException()
        {
            int endurance = -42;
            int passing = -1;

            Action createPlayer = () => CreatePlayer(endurance, passing);

            Assert.ThrowsException<ArgumentException>(createPlayer);
        }

        [TestMethod()]
        public void SetStats_StatsAreOver100_ThrowsExcpetion()
        {
            int endurance = 123;
            int passing = 9999;

            Action createPlayer = () => CreatePlayer(endurance, passing);

            Assert.ThrowsException<ArgumentException>(createPlayer);
        }

        [TestMethod()]
        public void GetOverall_EverythingIsValid_AverageOfPlayerStats()
        {
            Player player = CreatePlayer();

            decimal average =
                (decimal)((mockEndurance + mockSprint + mockDribble + mockPassing + mockShooting) / mockStatCount);

            decimal expected = 
                Math.Ceiling(average);

            Assert.AreEqual(expected, player.Overall);
        }
    }
}
