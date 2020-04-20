using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> romster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.romster = new List<Player>(capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }


        public void AddPlayer(Player player)
        {
            if (this.romster.Count < this.Capacity)
            {
                if (!this.romster.Contains(player))
                {
                    romster.Add(player);
                }
            }
        }

        public bool RemovePlayer(string name)
        {
            var isExist = false;

            if (this.romster.Any(p => p.Name == name))
            {
                var player = this.romster.First(p => p.Name == name);
                this.romster.Remove(player);

                isExist = true;
            }

            return isExist;
        }

        public void PromotePlayer(string name)
        {
            var player = this.romster.First(p => p.Name == name);
            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
           
        }

        public void DemotePlayer(string name)
        {
            var player = this.romster.First(p => p.Name == name);
            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
           
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            var kickedPlayers = new List<Player>();
            var newPlayersList = new List<Player>(Capacity);

            foreach (var player in this.romster)
            {
                if (player.Class == playerClass)
                {
                    kickedPlayers.Add(player);
                }
                else
                {
                    newPlayersList.Add(player);
                }

            }

            romster = newPlayersList;

            return kickedPlayers.ToArray();
        }

        public int Count => this.romster.Count;

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.romster)
            {
                sb.AppendLine($"{player.Name}: {player.Class}");
                sb.AppendLine(player.Rank);
                sb.AppendLine(player.Description);

            }

            return sb.ToString().TrimEnd();
        }
    }
}
