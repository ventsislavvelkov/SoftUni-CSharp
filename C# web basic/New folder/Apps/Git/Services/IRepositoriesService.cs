using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        void CreateRepository(string name ,string repositoryType, string userId);
        string GetRepositoryId(string name);
        IEnumerable<RepositoriesViewModel> All();
    }
}
