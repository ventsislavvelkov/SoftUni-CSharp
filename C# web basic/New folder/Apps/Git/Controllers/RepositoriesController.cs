using Git.ErrorMessages;
using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }
        public HttpResponse All()
        {

            var viewModel = this.repositoriesService.All();
            return this.View(viewModel);
        }
        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 10)
            {
                return this.Error(ErrorMessage.InvalidRepositoryName);
            }
            var userId = this.GetUserId();
            this.repositoriesService.CreateRepository(name, repositoryType, userId);
            return this.Redirect("/Repositories/All");
        }
    }
}
