using System.Collections.Generic;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        void Create(AddRepositoryInputModel repository);

        IEnumerable<RepositoriesViewModel> GetAll();

    }
}