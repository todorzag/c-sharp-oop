using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.UnitTests
{
    public class TestData
    {
        public static int mockEndurance = 12;
        public static int mockSprint = 23;
        public static int mockDribble = 64;
        public static int mockPassing = 14;
        public static int mockShooting = 98;

        public static decimal mockStatCount = 5m;

        public static string mockPlayerName = "Kircho";

        public static string mockTeamName = "Spartak Shturkovo";

        // Normal mock player
        public static Player CreatePlayer() =>
            new Player (mockPlayerName, mockEndurance, mockSprint, mockDribble, mockPassing, mockShooting);


        // Player with test name
        public static Player CreatePlayer(string name) =>
            new Player (name, mockEndurance, mockSprint, mockDribble, mockPassing, mockShooting);
  

        // Player with test Endurance and Passing
        public static Player CreatePlayer(int endurance, int passing) =>
            new Player (mockPlayerName, endurance, mockSprint, mockDribble, passing, mockShooting);


        public static Team CreateTeam() =>
            new Team(mockTeamName);

    }
}
