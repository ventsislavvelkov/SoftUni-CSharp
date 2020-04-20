using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
   public class Player
    {
        private Player()
        {
            this.Rank = "Trial";
            this.Description =  "n/a";
        }

        public Player(string name, string playerClass)
            :this()
        {
            this.Name = name;
            this.Class = playerClass;
        }
        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; } 

        public string Description { get; set; } 

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Player {this.Name}: {this.Class}")
                .AppendLine($"Rank: {this.Rank}")
                .AppendLine($"Description: {this.Description}");

            return sb.ToString().TrimEnd();
        }

        
    }
}
