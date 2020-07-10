

namespace P03_FootballBetting.Data.Models.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Initials { get; set; }
        public decimal Budget { get; set; }
      
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }
      
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }
      
        public int TownId { get; set; }
        public Town Town { get; set; }
    }
}
