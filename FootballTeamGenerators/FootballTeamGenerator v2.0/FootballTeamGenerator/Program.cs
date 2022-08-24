namespace FootballTeamGenerator
{
    public class Program
    {
        public static Dictionary<string, Team> teams = new Dictionary<string, Team>();

        public static void Main()
        {
            /*
            • A name cannot be null, empty, or white space. If not, print "A name should not be empty."
              - Doesn't create Team or Player

            • Stats should be in the range 0..100. If not, print "[Stat name] should be between 0 and 100."
              - Doesn't create Player
            */

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] input = line.Split(";");

                string action = input[0];
                string teamName = input[1];

                try
                {
                    switch (action)
                    {
                        case "Team":
                            CreateTeam(teamName);
                            break;

                        case "Add":
                            AddPlayerToTeam(input, teamName);
                            break;

                        case "Remove":
                            RemovePlayerFromTeam(input, teamName);
                            break;

                        case "Rating":
                            PrintTeamRating(teamName);
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
       
        private static void CreateTeam(string teamName)
        {
            Team team = new Team(teamName);
            teams.Add(teamName, team);
        }

        private static void AddPlayerToTeam(string[] input, string teamName)
        {
            if (teams.ContainsKey(teamName))
            {
                Player player = CreatePlayerFromInput(input);
                teams[teamName].AddPlayer(player);
            }
            else
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }  
        }

        private static void RemovePlayerFromTeam(string[] input, string teamName)
        {
            string playerName = input[2];
          
            if (teams.ContainsKey(teamName))
            {
                Team team = teams[teamName];

                if (team.HasPlayer(playerName, team.Name))
                {
                    team.RemovePlayer(playerName);
                }
                else
                {
                    throw new ArgumentException($"Player {playerName} is not in {team.Name} team.");
                }
            }
            else
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }

        private static void PrintTeamRating(string teamName)
        {
            if (teams.ContainsKey(teamName))
            {
                Team team = teams[teamName];
                Console.WriteLine($"{team.Name} - {team.Rating}");
            }
            else
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        } 
            
    }
}