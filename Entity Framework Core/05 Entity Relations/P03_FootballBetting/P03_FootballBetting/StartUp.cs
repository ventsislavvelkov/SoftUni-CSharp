using System;
using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
   public class StartUp
    {
       public static void Main()
        {
            using var db = new FootballBettingContext();
        }
    }
}
