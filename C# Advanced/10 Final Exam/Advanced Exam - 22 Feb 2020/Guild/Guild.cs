using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        private Guild()
        {
            this.roster = new List<Player>();
        }
        public Guild(string name, int capacity)
          : this()
        {
            this.Name = name;
            this.Capacity = capacity;

        }

        public string Name { get; set; }

        public int Capacity { get; set; }


        public void AddPlayer(Player player)
        {
            if (this.roster.Count + 1 <= this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var isExist = false;

            if (this.roster.Any(p => p.Name == name))
            {
                var player = this.roster.FirstOrDefault(p => p.Name == name);

                if (player != null)
                {
                    this.roster.Remove(player);
                    isExist = true;
                }



            }

            return isExist;
        }

        public void PromotePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                player.Rank = "Member";
            }

        }

        public void DemotePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                player.Rank = "Trial";
            }

        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            var kickedPlayers = new List<Player>();
            var newPlayersList = new List<Player>();

            foreach (var player in this.roster)
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

            roster = newPlayersList;

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
