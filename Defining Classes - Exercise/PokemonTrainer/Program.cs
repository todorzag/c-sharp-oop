namespace PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            List<Trainer> trainers = new List<Trainer>();

            while (line != "Tournament")
            {
                string[] split = line.Split(" ");

                string trainerName = split[0];
                string pokemonName = split[1];
                string pokemonElement = split[2];
                int pokemonHealth = int.Parse(split[3]);

                Trainer trainer = FindTrainer(trainers, trainerName);

                if (trainer == null)
                {
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                    trainers.Add(new Trainer(trainerName, pokemon));
                }
                else
                {
                    trainer.AddPokemon(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "End")
            {
                AllTrainersTournamentBattle(trainers, line);

                line = Console.ReadLine();
            }

            List<Trainer> sortedTrainers = SortTrainers(trainers);

            PrintTrainers(sortedTrainers);
        }

        public static Trainer FindTrainer(List<Trainer> trainers, string trainerName)
        {
            return trainers.Find(trainer => trainer.Name.Equals(trainerName));
        }

        public static void AllTrainersTournamentBattle(List<Trainer> trainers, string element)
        {
            foreach (Trainer trainer in trainers)
            {
                trainer.TournamentBattle(element);
            }
        }

        public static List<Trainer> SortTrainers(List<Trainer> trainers)
        {
            return trainers.OrderByDescending(trainer => trainer.NumberOfBadges).ToList();
        }

        public static void PrintTrainers(List<Trainer> trainers)
        {
            foreach (Trainer trainer in trainers)
            {
                Console.WriteLine(trainer.ToString());
            }
        }
    }
}