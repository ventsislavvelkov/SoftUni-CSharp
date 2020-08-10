using System.Collections.Generic;
using CounterStrike.Models.Guns;
using CounterStrike.Repositories.Contracts;

namespace CounterStrike.Repositories
{
    public class GunRepository :IRepository<Gun>
    {
        public IReadOnlyCollection<Gun> Models { get; }
        public void Add(Gun model)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(Gun model)
        {
            throw new System.NotImplementedException();
        }

        public Gun FindByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}