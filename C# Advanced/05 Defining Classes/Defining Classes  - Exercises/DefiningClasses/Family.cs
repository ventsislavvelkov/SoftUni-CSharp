using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace DefiningClasses
{
    public class Family
    {
        private readonly HashSet<Person> members;

        public Family()
        {
            this.members = new HashSet<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = this.members
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();

            return oldestPerson;
        }

    }
}
