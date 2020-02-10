using System;
using System.Collections.Generic;
using System.Linq;

namespace _05TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamCounter = int.Parse(Console.ReadLine());

            List<Teams> listOfTeams = new List<Teams>();

            for (int i = 1; i <= teamCounter; i++)
            {
                string[] tokens = Console.ReadLine().Split("-");
                string creatorOfTeam = tokens[0];
                string currentTeam = tokens[1];

                if (listOfTeams.Any(x => x.TeamCreator == creatorOfTeam))
                {
                    Console.WriteLine($"{creatorOfTeam} cannot create another team!");
                }
                else if (listOfTeams.Any(x => x.Team == currentTeam))
                {
                    Console.WriteLine($"Team {currentTeam} was already created!");
                }
                else
                {
                    listOfTeams.Add(new Teams(creatorOfTeam, currentTeam));
                    Console.WriteLine($"Team {currentTeam} has been created by {creatorOfTeam}!");
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] tokens = input.Split("->");
                string userToJoinTeam = tokens[0];
                string currentTeam = tokens[1];

                if (!listOfTeams.Any(t => t.Team == currentTeam))
                {
                    Console.WriteLine($"Team {currentTeam} does not exist!");
                }
                else if (listOfTeams.Any(x => x.teamMembers.Contains(userToJoinTeam)) ||
                    listOfTeams.Any(y => y.TeamCreator == userToJoinTeam))
                {
                    Console.WriteLine($"Member {userToJoinTeam} cannot join team {currentTeam}!");
                }
                else
                {
                    int indexToAdd = listOfTeams.FindIndex(x => x.Team == currentTeam);
                    listOfTeams[indexToAdd].teamMembers.Add(userToJoinTeam);
                }
            }

            listOfTeams = listOfTeams.OrderByDescending(x => x.teamMembers.Count).ThenBy(y => y.Team).ToList();
            List<string> disbandedTeams = new List<string>();

            for (int currentTeam = 0; currentTeam < listOfTeams.Count; currentTeam++)
            {
                if (listOfTeams[currentTeam].teamMembers.Count == 0)
                {
                    disbandedTeams.Add(listOfTeams[currentTeam].Team);
                    continue;
                }

                PrintValidTeams(listOfTeams, currentTeam);
            }

            PrintDisbandedTeams(disbandedTeams);
        }

        private static void PrintValidTeams(List<Teams> listOfTeams, int currentTeam)
        {
            Console.WriteLine(listOfTeams[currentTeam].Team);
            Console.WriteLine($"- {listOfTeams[currentTeam].TeamCreator}");

            listOfTeams[currentTeam].teamMembers.Sort();

            foreach (var member in listOfTeams[currentTeam].teamMembers)
            {
                Console.WriteLine($"-- {member}");
            }
        }

        private static void PrintDisbandedTeams(List<string> disbandedTeams)
        {
            Console.WriteLine("Teams to disband:");

            disbandedTeams.Sort();
            disbandedTeams.ForEach(t => Console.WriteLine(t));
        }
    }

    class Teams
    {
        public string TeamCreator { get; set; }
        public string Team { get; set; }
        public List<string> teamMembers = new List<string>();

        public Teams(string creatorOfTeam, string team)
        {
            TeamCreator = creatorOfTeam;
            Team = team;
        }
    }
}