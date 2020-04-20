using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
    
        private  List<Player> roster;

        private Guild()
        {
            this.roster = new List<Player>();
        }
        public Guild(string name, int capacity)
        :this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var isRemoved = false;
            if (this.roster.Any(p=>p.Name == name))
            {
                var player = this.roster.FirstOrDefault(p => p.Name == name);
                this.roster.Remove(player);
                isRemoved = true;
            }
            return isRemoved;
        }

        public void PromotePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(p => p.Name == name);
            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(p => p.Name == name);
            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            var kickedPlayers = new List<Player>();

            foreach (var player in this.roster)
            {
                if (player.Class == playerClass)
                {
                    kickedPlayers.Add(player);
                }
            }

            this.roster = this.roster.Where(x => x.Class != playerClass).ToList();

            return kickedPlayers.ToArray();
        }

        public int Count => this.roster.Count;

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            if (this.roster.Count > 0)
            {
                foreach (var player in this.roster)
                {
                    sb.AppendLine($"{player.Name}: {player.Class}");
                    sb.AppendLine(player.Rank);
                    sb.AppendLine(player.Description);

                }
            }
          
            return sb.ToString().TrimEnd();
        }

    }
}
