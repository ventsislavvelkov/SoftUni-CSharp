using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        void CreateCommit(string id, string description, string userId);
        IEnumerable<CommitsViewModel> All(string userId);
        void DeleteCommit(string id, string creatorId);
        CommitCreateModel GetRepositoryNameAndId(string id);
    }
}
