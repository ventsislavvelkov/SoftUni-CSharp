using System;

namespace Git.ViewModels.Repositories
{
    public class AddRepositoryInputModel
    {
        public string Name { get; set; }

        public DateTime CreateOn { get; set; }

        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }
    }
}