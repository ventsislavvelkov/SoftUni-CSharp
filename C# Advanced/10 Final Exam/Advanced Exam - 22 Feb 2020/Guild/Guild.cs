using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        //private Guild()
        //{
        //    this.roster = new List<Player>();
        //}
        public Guild(string name, int capacity)
        // :this()
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity && !this.roster.Any(p => p.Name == player.Name))
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var isRemoved = false;
            var player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                this.roster.Remove(player);
                isRemoved = true;
            }
            return isRemoved;
        }

        public void PromotePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player != null && player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player != null && player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string curClass)
        {
            Player[] allPlayerByClassFilter = this.roster.Where(p => p.Class == curClass).ToArray();
            if (allPlayerByClassFilter.Any())
            {
                this.roster.RemoveAll(x => x.Class == curClass);
            }
            return allPlayerByClassFilter;
        }

        public int Count => this.roster.Count;

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            sb.AppendLine(string.Join(Environment.CommandLine, this.roster));

            return sb.ToString().TrimEnd();
        }
    }
}
