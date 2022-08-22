namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main()
        {
            /*
            • A name cannot be null, empty, or white space. If not, print "A name should not be empty."
              - Doesn't create Team or Player

            • Stats should be in the range 0..100. If not, print "[Stat name] should be between 0 and 100."
              - Doesn't create Player
            */

            string line = Console.ReadLine();

            List<Team> teams = new List<Team>();

            while (line != "END")
            {
                string[] input = line.Split(";");

                string action = input[0];
                string teamName = input[1];

                Team team;

                try
                {
                    // Only action that doesn't require CheckIfTeamExists() and FindTeam();
                    if (action == "Team")
                    {
                        team = new Team(teamName);
                        teams.Add(team);
                    }
                    else
                    {
                        CheckIfTeamExists(teams, teamName);
                        team = FindTeam(teams, teamName);
                    }

                    switch (action)
                    {
                        case "Add":
                            AddPlayerToTeam(input, team);
                            break;

                        case "Remove":
                            RemovePlayerFromTeam(input, team);
                            break;

                        case "Rating":
                            PrintTeamRating(team);
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                line = Console.ReadLine();
            }
        }

        // Create class Stat with name and value
        private static Player CreatePlayerFromInput(string[] input)
        {
            string playerName = input[2];

            int endurance = int.Parse(input[3]);
            int sprint = int.Parse(input[4]);
            int dribble = int.Parse(input[5]);
            int passing = int.Parse(input[6]);
            int shooting = int.Parse(input[7]);

            return new Player
                (playerName, endurance, sprint, dribble, passing, shooting);
        }
        private static void CheckIfTeamExists(List<Team> teams, string teamName)
        {
            bool teamDoesntExist = !teams.Any(team => team.Name == teamName);

            if (teamDoesntExist)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }

        private static Team? FindTeam(List<Team> teams, string teamName) => 
            teams.Find(team => team.Name == teamName);

        private static void AddPlayerToTeam(string[] input, Team team)
        {
            Player player = CreatePlayerFromInput(input);
            team.AddPlayer(player);
        }

        private static void RemovePlayerFromTeam(string[] input, Team team)
        {
            string playerName = input[2];
            team.CheckIfPlayerInTeam(playerName, team.Name);

            team.RemovePlayer(playerName);
        }

        private static void PrintTeamRating(Team team) => 
            Console.WriteLine($"{team.Name} - {team.Rating}");
    }
}