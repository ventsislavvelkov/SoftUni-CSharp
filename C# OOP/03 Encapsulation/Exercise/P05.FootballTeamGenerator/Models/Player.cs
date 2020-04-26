using System;
using System.Collections.Generic;
using System.Text;
using P05.FootballTeamGenerator.Comman;

namespace P05.FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;

        public Player(string name , Stats stats )
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public Stats Stats { get; }

        public double OverallSkill => this.Stats.AverageStats;
    }
}
