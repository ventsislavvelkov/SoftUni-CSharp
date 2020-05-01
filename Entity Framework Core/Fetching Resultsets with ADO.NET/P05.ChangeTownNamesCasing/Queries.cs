using System;
using System.Collections.Generic;
using System.Text;

namespace P05.ChangeTownNamesCasing
{
    class Queries
    {
        public static string TakeCountryName = @"SELECT t.Name AS [TownName]
                                                   FROM Towns as t
                                                        JOIN Countries AS c ON c.Id = t.CountryCode
                                                  WHERE c.Name = @countryName";

        public static string UpdateTownNames = @"UPDATE Towns
                                                    SET Name = UPPER(Name)
                                                  WHERE CountryCode = (SELECT c.Id 
                                                                         FROM Countries AS c 
                                                                        WHERE c.Name = @countryName)";
    }
}
