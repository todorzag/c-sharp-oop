using FootballTeamGenerator.Stats;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            • A name cannot be null, empty, or white space. If not, print "A name should not be empty."
              - Doesn't create Team or Player

            • Stats should be in the range 0..100. If not, print "[Stat name] should be between 0 and 100."
              - Sets stat to zero
            */

            string line = Console.ReadLine();

            List<Team> teams = new List<Team>();

            while (line != "END")
            {
                string[] input = line.Split(";");
                string action = input[0];

                string teamName = input[1];
                string playerName;
                bool teamExists;

                switch (action)
                {
                    case "Team":
                        try
                        {
                            teams.Add(new Team(teamName));
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;

                    case "Add":
                        Team? teamToAdd = FindTeam(teams, teamName);
                        teamExists = teamToAdd != null;

                        if (teamExists)
                        {
                            playerName = input[2];
                            List<IStat> stats = GenerateStats(input);

                            try
                            {
                                Player player = new Player(playerName, stats);

                                teamToAdd.AddPlayer(player);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                        break;

                    case "Remove":
                        Team? teamToRemoveFrom = FindTeam(teams, teamName);
                        teamExists = teamToRemoveFrom != null;

                        if (teamExists)
                        {
                            playerName = input[2];
                            bool inTeam = teamToRemoveFrom.CheckIfPlayerInTeam(playerName);

                            if (inTeam)
                            {
                                teamToRemoveFrom.RemovePlayerByName(playerName);
                            }
                            else
                            {
                                Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                            }
                        }

                        break;

                    case "Rating":
                        Team? teamToFind = FindTeam(teams, teamName);
                        teamExists = teamToFind != null;

                        if (teamExists)
                        {
                            Console.WriteLine($"{teamName} - {teamToFind.Rating}");
                        }

                        break;
                }


                line = Console.ReadLine();

            }
        }

        // Create class Stat with name and value
        private static List<IStat> GenerateStats(string[] input)
        {
            List<IStat> stats = new List<IStat>();

            int endurance = int.Parse(input[3]);
            int sprint = int.Parse(input[4]);
            int dribble = int.Parse(input[5]);
            int passing = int.Parse(input[6]);
            int shooting = int.Parse(input[7]);

            stats.Add(new Endurance(endurance));
            stats.Add(new Sprint(sprint));
            stats.Add(new Dribble(dribble));
            stats.Add(new Passing(passing));
            stats.Add(new Shooting(shooting));

            return stats;
        }

        private static Team? FindTeam(List<Team> teams, string teamName)
        {
            Team team = teams.Find(team => team.Name == teamName);

            if (team == null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }

            return team;
        }
    }
}