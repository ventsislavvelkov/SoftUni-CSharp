

namespace P03_FootballBetting.Data.Models.Model
{
   public class Town
    {
        public int  TownId { get; set; }

        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
