using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    internal class Pokemon
    {
        public string Name { get; }

        public string Element { get; }

        public int Health { get; set; }

        public Pokemon(string name, string element, int health)
        {
            Name = name;
            Element = element;
            Health = health;
        }
    }
}
