using System;
using System.Collections.Generic;
using System.Text;

namespace P02.VillainNames
{
    class Queries
    {
        public static string VillainNames = @"SELECT [Name], 
                                            COUNT(mv.MinionId) AS [MinionsCount]
                                       FROM Villains AS v
                                            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                   GROUP BY [Name]
                                     HAVING COUNT(mv.MinionId) > 3
                                   ORDER BY COUNT(mv.MinionId) DESC";
    }
}
