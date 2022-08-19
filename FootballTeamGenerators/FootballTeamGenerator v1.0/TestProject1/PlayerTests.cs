using FootballTeamGenerator;
using FootballTeamGenerator.Stats;

namespace FootballTeamGenerator.UnitTests
{
    [TestClass]
    public class PlayerTests : TestData
    {
        [TestMethod()]
        public void SetName_NameValidString_PlayerNameEqualToName()
        {
            // Aranged default

            // Act 
            Player player = CreatePlayer();

            // Assert
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
            // Arange
            string name = null;

            // Act 
            Action createPlayer = () => CreatePlayer(name);

            // Assert
            Assert.ThrowsException<ArgumentException>(createPlayer);
        }

        [TestMethod()]
        public void SetStats_StatsAreInRange_StatsAreSet()
        {
            Player player = CreatePlayer();

            Assert.AreEqual(player.Stats, mockStats);
        }

        [TestMethod()]
        public void SetStats_StatsAreUnder0_WritesMessageOnConsoleForRange()
        {
            List<IStat> stats = new List<IStat>
            {
                new Endurance(-1),
                new Sprint(22),
                new Dribble(53),
                new Passing(-34),
                new Shooting(3)
            };

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Player player = CreatePlayer(stats);

            var output = stringWriter.ToString();

            Assert.AreEqual("Endurance should be between 0 and 100.\r\n" +
                "Passing should be between 0 and 100.\r\n", output);
            
        }

        [TestMethod()]
        public void SetStats_StatsAreUnder0_InvalidStatsShouldEqual0()
        {
            List<IStat> stats = new List<IStat>
            {
                new Endurance(-1),
                new Sprint(22),
                new Dribble(53),
                new Passing(-34),
                new Shooting(3)
            };

            Player player = CreatePlayer(stats);

            var endurance = player.Stats.Find(stat => stat.Name == "Endurance");
            var passing = player.Stats.Find(stat => stat.Name == "Passing");

            Assert.AreEqual(0, endurance.Value);
            Assert.AreEqual(0, passing.Value);
        }

        [TestMethod()]
        public void SetStats_StatsAreOver100_WritesMessageOnConsoleForRange()
        {
            List<IStat> stats = new List<IStat>
            {
                new Endurance(143),
                new Sprint(22),
                new Dribble(53),
                new Passing(243),
                new Shooting(3)
            };

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Player player = CreatePlayer(stats);

            var output = stringWriter.ToString();

            Assert.AreEqual("Endurance should be between 0 and 100.\r\n" +
                "Passing should be between 0 and 100.\r\n", output);

        }

        [TestMethod()]
        public void SetStats_StatsAreOver100_InvalidStatsShouldEqual0()
        {
            List<IStat> stats = new List<IStat>
            {
                new Endurance(143),
                new Sprint(22),
                new Dribble(53),
                new Passing(243),
                new Shooting(3)
            };

            Player player = CreatePlayer(stats);

            var endurance = player.Stats.Find(stat => stat.Name == "Endurance");
            var passing = player.Stats.Find(stat => stat.Name == "Passing");

            Assert.AreEqual(0, endurance.Value);
            Assert.AreEqual(0, passing.Value);
        }

        [TestMethod()]
        public void GetOverall_EverythingIsValid_AverageOfPlayerStats()
        {
            Player player = CreatePlayer();

            decimal expected = Math.Ceiling((decimal)mockStats.Average(x => x.Value));

            Assert.AreEqual(expected, player.Overall);
        }
    }
}
