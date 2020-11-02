using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.ViewModels.Repositories;
using SUS.MvcFramework;

namespace Git.Services
{
    public class RepositoriesService :IRepositoriesService
    {

        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(AddRepositoryInputModel repository)
        {

            var dbRepository = new Repository
            {
                Name = repository.Name,
                CreatedOn = repository.CreateOn,
                IsPublic = repository.IsPublic,
                OwnerId = repository.OwnerId,
            };

            this.db.Repositories.Add(dbRepository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoriesViewModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}