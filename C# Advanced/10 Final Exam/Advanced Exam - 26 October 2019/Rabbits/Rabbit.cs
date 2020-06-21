using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    public class Rabbit
    {
        public Rabbit()
        {
            this.Available = true;
        }

        public Rabbit(string name, string species)
            : base()
        {
            this.Name = name;
            this.Species = species;
        }
        public string Name { get; set; }
        public string Species { get; set; }
        public bool Available { get; set; }

        public override string ToString()
        {
            return $"Rabbit ({this.Species}): {this.Name}";
        }
    }
}
