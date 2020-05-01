using System;
using System.Collections.Generic;
using System.Text;

namespace P03.MinionNames
{
    class Queries
    {
        public static string MinionsQuery = @"SELECT ROW_NUMBER() OVER(ORDER BY [Name]) AS RowNumber, 
                                               m.[Name] AS MinionName, 
                                               m.Age AS MinionAge
                                          FROM MinionsVillains AS mv
                                               JOIN Minions AS m ON m.Id = mv.MinionId
                                         WHERE mv.VillainId = @Id
                                      ORDER BY m.[Name]";

        public static string VillainsIdQuery = @"SELECT [Name] FROM Villains WHERE Id = @Id";
    }
}
