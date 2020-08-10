using System.Collections.Generic;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map :IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;

        public Map()
        {
            this.counterTerrorists = new List<IPlayer>();
            this.terrorists = new List<IPlayer>();
        }
        public string Start(ICollection<IPlayer> players)
        {
            
        }
    }
}