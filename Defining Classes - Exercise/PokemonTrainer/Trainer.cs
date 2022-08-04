using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    internal class Trainer
    {
        private List<Pokemon> _pokemons = new List<Pokemon>();

        public string Name { get; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons
        {
            get => _pokemons;
            set => _pokemons = value;
        }

        public Trainer(string name, Pokemon pokemon)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons.Add(pokemon);
        }

        private bool CheckIfHasPokemonElement(string element)
        {
            return Pokemons.Any(pokemon => pokemon.Element.Equals(element));
        }

        private void AddBadge()
        {
            NumberOfBadges++;
        }

        private void DamagePokemon()
        {
            foreach (Pokemon pokemon in Pokemons)
            {
                pokemon.Health -= 10;
            }

            KillPokemon();
        }

        private void KillPokemon()
        {
            Pokemons = Pokemons.Where(pokemon => pokemon.Health > 0).ToList();
        }

        public void TournamentBattle(string element)
        {
            if (CheckIfHasPokemonElement(element))
            {
                AddBadge();
            }
            else
            {
                DamagePokemon();
            }
        }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public override string ToString()
        {
            return $"{Name} {NumberOfBadges} {Pokemons.Count}";
        }
    }
}
