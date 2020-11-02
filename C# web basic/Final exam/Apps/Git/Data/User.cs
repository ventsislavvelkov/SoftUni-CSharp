using System;
using System.Collections.Generic;
using SUS.MvcFramework;

namespace Git.Data
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Role = IdentityRole.User;
            this.Repositories = new HashSet<Repository>();
            this.Commits = new HashSet<Commit>();
        }

        public virtual ICollection<Repository> Repositories { get; set; }
        public virtual ICollection<Commit> Commits { get; set; }
    }
}