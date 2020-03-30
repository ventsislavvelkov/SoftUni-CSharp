using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public string Element
        {
            get => this.element;
            set => this.element = value;
        }
        public int Health
        {
            get => this.health;
            set => this.health = value;
        }

       
    }
}
