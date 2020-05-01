using System;
using System.Collections.Generic;
using System.Text;

namespace P06.RemoveVillain
{
    class Queries
    {
        public static string TakeVillainId = "SELECT Name FROM Villains WHERE Id = @villainId";

        public static string DeleteVillainFromMinionsVillains = @"DELETE FROM MinionsVillains 
                                                                        WHERE VillainId = @villainId";

        public static string DeleteVillainFromVillains = @"DELETE FROM Villains
                                                                 WHERE Id = @villainId";
    }
}
