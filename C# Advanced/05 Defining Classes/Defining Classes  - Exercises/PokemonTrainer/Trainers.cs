using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainers
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemon;
        private const int defaultNumberOfBadges = 0;

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public int NumberOfBadges
        {
            get => this.numberOfBadges;
            set => this.numberOfBadges = value;
        }
        public List<Pokemon> Pokemons
        {
            get => this.pokemon;
            set => this.pokemon = value;
        }

        public Trainers(string name)
        {
            this.Name = name;
            this.NumberOfBadges = defaultNumberOfBadges;
            this.Pokemons = new List<Pokemon>();
        }

        public override string ToString()
        {
            return $"{Name} {NumberOfBadges} {Pokemons.Count}";
        }
    }
}
