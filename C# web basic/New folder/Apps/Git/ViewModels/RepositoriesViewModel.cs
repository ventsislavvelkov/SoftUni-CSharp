using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Git.ViewModels
{
   public class RepositoriesViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string OwnerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ParseDateCreatedOn => this.CreatedOn.ToString("g");
        public int CommitsCount { get; set; }
        public bool  IsPublic { get; set; }
    }
}
