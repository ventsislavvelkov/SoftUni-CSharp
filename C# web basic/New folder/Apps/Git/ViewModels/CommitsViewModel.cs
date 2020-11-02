using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels
{
   public class CommitsViewModel
    {
        public string Id { get; set; }
        public string RepositoryName { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ParseCreatedOn => this.CreatedOn.ToString("g");
    }
}
