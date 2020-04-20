using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    class Class1
    {
    }

    public class Guildii
    {
        private int capacity;
        private List<Player> players;

        public Guildii(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.players = new List<Player>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MyProperty { get; set; }

        public void AddPlayer(Player player)
        {
            if (this.players.Count < this.Capacity)
            {
                players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var isRemoved = false;
            if (this.players.Any(p => p.Name == name))
            {
                var player = this.players.Where(p => p.Name == name).First();
                this.players.Remove(player);
                isRemoved = true;
            }
            return isRemoved;
        }

        public void PromotePlayer(string name)
        {
            var player = this.players.Where(p => p.Name == name).FirstOrDefault();
            player.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            var player = this.players.Where(p => p.Name == name).FirstOrDefault();
            player.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            var kickedPlayers = new List<Player>();

            foreach (var player in this.players)
            {
                if (player.Class == playerClass)
                {
                    kickedPlayers.Add(player);
                }
            }

            // this.players.RemoveAll(p => p.Class == playerClass);
            this.players = this.players.Where(x => x.Class != playerClass).ToList();
            return kickedPlayers.ToArray();
        }

        public int Count => this.players.Count;

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.players)
            {
                sb.AppendLine($"{player.Name}: {player.Class}");
                sb.AppendLine(player.Rank);
                sb.AppendLine(player.Description);

            }
            return sb.ToString().TrimEnd();
        }
