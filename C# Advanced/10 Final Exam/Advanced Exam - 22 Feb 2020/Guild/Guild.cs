using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    class Guild
    {
        private Dictionary<string, HashSet<Player>> players;
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Guild(string name, int capacity)
        {
            this.Name = name;

            this.Capacity = capacity;
        }
    }
}
