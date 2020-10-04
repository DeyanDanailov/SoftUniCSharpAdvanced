using System;
using System.Collections.Generic;
using System.Text;

namespace P09.PokemonTrainer
{
    
    public class Trainer
    {
        public Trainer()
        {
            this.NumberOfBadges = 0;
            this.Pokemons = new List<Pokemon>();
        }
        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}
