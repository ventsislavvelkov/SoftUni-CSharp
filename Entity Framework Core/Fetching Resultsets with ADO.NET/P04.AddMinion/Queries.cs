using System;
using System.Collections.Generic;
using System.Text;

namespace P04.AddMinion
{
    class Queries
    {
        public static string TakeTownId = "SELECT Id FROM Towns WHERE Name = @townName";

        public static string InsertTownName = "INSERT INTO Towns (Name) VALUES (@townName)";

        public static string TakeVillainId = "SELECT Id FROM Villains WHERE Name = @Name";

        public static string InsertVillain = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public static string TakeMinionId = "SELECT Id FROM Minions WHERE Name = @Name";

        public static string InsertMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public static string InsertMinionVillain = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
    }
}
