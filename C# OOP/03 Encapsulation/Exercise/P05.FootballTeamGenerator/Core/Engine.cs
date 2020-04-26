using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P05.FootballTeamGenerator.Comman;
using P05.FootballTeamGenerator.Models;

namespace P05.FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {

                try
                {
                    string[] tokens = command.Split(';', StringSplitOptions.None).ToArray();

                    string cmdType = tokens[0];

                    if (cmdType == "Team")
                    {
                        AddTeam(tokens);
                    }
                    else if (cmdType == "Add")
                    {
                        AddPlayerToTeam(tokens);
                    }
                    else if (cmdType == "Remove")
                    {
                        RemovePlayer(tokens);
                    }
                    else if (cmdType == "Rating")
                    {
                        PrintRating(tokens);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                
            }
        }

        private void PrintRating(string[] tokens)
        {
            string teamName = tokens[1];

            this.ValidateTeamExists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }

        private void RemovePlayer(string[] tokens)
        {
            string teamName = tokens[1];
            string playerName = tokens[2];

            this.ValidateTeamExists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private void AddPlayerToTeam(string[] tokens)
        {
            string teamName = tokens[1];
            string playerName = tokens[2];

            this.ValidateTeamExists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Stats stats = this.CreateStats(tokens.Skip(3).ToArray());

            Player player = new Player(playerName, stats);

            team.AddPlayer(player);
        }

        private Stats CreateStats(string[] tokkens)
        {
            int endurance = int.Parse(tokkens[0]);
            int sprint = int.Parse(tokkens[1]);
            int dribble = int.Parse(tokkens[2]);
            int passing = int.Parse(tokkens[3]);
            int shooting = int.Parse(tokkens[4]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            return stats;



        }

        private void ValidateTeamExists(string name)
        {
            if (!this.teams.Any(t=>t.Name == name))
            {
                throw new ArgumentException(String.Format(GlobalConstants.MissingTeamExceptionMessage, name));
            }
        }
        private void AddTeam(string[] tokens)
        {
            string teamName = tokens[1];

            Team team = new Team(teamName);

            this.teams.Add(team);
        }
    }
}
