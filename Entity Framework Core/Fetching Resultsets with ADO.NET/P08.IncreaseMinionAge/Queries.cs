using System;
using System.Collections.Generic;
using System.Text;

namespace P08.IncreaseMinionAge
{
    class Queries
    {
        public static string UpdateMinions = @"UPDATE Minions
                                                  SET Name = UPPER(LEFT(Name, 1)) + 
                                                             SUBSTRING(Name, 2, LEN(Name)),
                                                             Age += 1
                                                             WHERE Id = @Id";

        public static string TakeMinionsNameAndAge = "SELECT Name, Age FROM Minions";
    }
}
