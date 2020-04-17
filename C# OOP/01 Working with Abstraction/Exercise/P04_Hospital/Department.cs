using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {
        private const int MAX_CAPACITY = 3;

        private readonly List<Room> rooms;

        private Department()
        {
            this.rooms = new List<Room>();
            this.InitializeRools();
        }

        public Department(string name)
        : this()
        {
            this.Name = name;
        }
        public string Name { get; }

        public IReadOnlyCollection<Room> Rooms => this.rooms;

        public Room GetFirstFreeRoom()
        {
            return this.rooms.First(r => r.Count < MAX_CAPACITY); 
        }

        private void InitializeRools()
        {
            for (byte i = 1; i <= 20; i++)
            {
                this.rooms.Add(new Room(i));
            }
        }
    }
}
