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
              - Sets stat to zero
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
                            Player player = CreatePlayerFromInput(input);
                            team.AddPlayer(player);

                            break;

                        case "Remove":
                            string playerName = input[2];
                            team.CheckIfPlayerInTeam(playerName, teamName);

                            team.RemovePlayer(playerName);

                            break;

                        case "Rating":
                            Console.WriteLine($"{team.Name} - {team.Rating}");

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

    }
}