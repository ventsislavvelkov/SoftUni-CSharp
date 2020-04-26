using System;
using System.Collections.Generic;
using System.Text;

namespace P05.FootballTeamGenerator.Comman
{
   public static class GlobalConstants
   {
       public static string InvalidStatExceptionMessage = "{0} should be between {1} and {2}.";

       public static string EmptyNameExceptionMessage = "A {0} should no t be empty.";

       public static string RemovingMessingPlayerExceptionMessage = "Player {0} is not in {1} team.";

       public static string MissingTeamExceptionMessage = "Team {0} does not exist."; 
   }
}
