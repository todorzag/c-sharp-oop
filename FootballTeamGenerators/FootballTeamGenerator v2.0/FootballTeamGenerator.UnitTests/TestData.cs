using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.UnitTests
{
    public class TestData
    {
        public static int stubEndurance = 11;
        public static int stubSprint = 12;
        public static int stubDribble = 13;
        public static int stubPassing = 14;
        public static int stubShooting = 15;

        public static string stubPlayerName = "Kircho";

        public static string stubTeamName = "Spartak Shturkovo";

        // Player with mock name
        public static Player CreatePlayer(string name) =>
            new Player(name, stubEndurance, stubSprint, stubDribble, stubPassing, stubShooting);

        // Player with mock Endurance and Passing
        public static Player CreatePlayer(int endurance, int passing) =>
            new Player(stubPlayerName, endurance, stubSprint, stubDribble, passing, stubShooting);

        // Team with players
        public static Team CreateTeamWithPlayers()
        {
            Team team = new Team(stubTeamName);
            team.AddPlayer(CreatePlayer(stubPlayerName));
            team.AddPlayer(CreatePlayer(stubPlayerName));
            team.AddPlayer(CreatePlayer(stubPlayerName));

            return team;
        }
    }
}
