using System.Collections.Generic;
using CounterStrike.Models.Players;
using CounterStrike.Repositories.Contracts;

namespace CounterStrike.Repositories
{
    public class PlayerRepository  :IRepository<Player>
    {
        public IReadOnlyCollection<Player> Models { get; }
        public void Add(Player model)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(Player model)
        {
            throw new System.NotImplementedException();
        }

        public Player FindByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}