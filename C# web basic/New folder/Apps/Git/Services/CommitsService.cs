using Git.Data;
using Git.Models;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CommitsViewModel> All(string userId )
        {
            //Future Upgrade -> Users can see all his commits , but can he see the commits on his repository from other users?
            var allCommits=  this.db.Commits.Select(x => new CommitsViewModel
            {
                Id=x.Id,
                RepositoryName=x.Repository.Name,
                Description=x.Description,
                CreatedOn=x.CreatedOn,
                CreatorId = x.CreatorId

            }).ToList();

            var ownerCommits = new List<CommitsViewModel>();
            foreach (var commit in allCommits)
            {
                if (userId ==commit.CreatorId)
                {
                    ownerCommits.Add(commit);
                }
            }

            return ownerCommits;
        }

        //CreateCommit
        public void CreateCommit(string id, string description,string userId)
        {
            var commit = new Commit
            {
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = id,
                Description = description
            };
            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public CommitCreateModel GetRepositoryNameAndId(string id)
        {
            var repository = this.db.Repositories.FirstOrDefault(x => x.Id == id);

            var commitCreateModel = new CommitCreateModel
            {
                Id = repository.Id,
                Name = repository.Name
            };

            return commitCreateModel;
           
        }
        //DeleteCommit
        public void DeleteCommit(string id , string creatorId)
        {
            var commit = this.db.Commits.FirstOrDefault(x => x.Id == id);
            if (commit.CreatorId != creatorId)
            {
                return;
            }
            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }
    }
}
