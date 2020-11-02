using Git.Data;
using Git.Models;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<RepositoriesViewModel> All()
        {
            var Allrepositories = this.db.Repositories.Select(x => new RepositoriesViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreatedOn = x.CreatedOn,
                CommitsCount = x.Commits.Count(),
                Owner = x.Owner.Username,
                OwnerId = x.OwnerId,
                IsPublic = x.IsPublic
            }).ToList();

            var repositoriesToShow = new List<RepositoriesViewModel>();
            foreach (var repo in Allrepositories)
            {
                if (repo.IsPublic == true)
                {
                    repositoriesToShow.Add(repo);
                }
            }

            return repositoriesToShow;

        }

        public void CreateRepository(string name, string repositoryType, string userId)
        {
            bool isPublic = false;
            if (repositoryType == "Public")
            {
                isPublic = true;
            }
            var repository = new Repository
            {
                Name = name,
                IsPublic = isPublic,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };
            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public string GetRepositoryId(string name)
        {
            var repository = this.db.Repositories.FirstOrDefault(x => x.Name == name);
            return repository.Id;
        }
    }
}
