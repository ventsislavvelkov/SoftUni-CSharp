using System;
using Git.Data;
using Git.Services;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoryService;

        public RepositoriesController(IRepositoriesService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(AddRepositoryInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.Name))
            {
                return this.Error("Name is required");
            }

            if (input.Name.Length < 3 || input.Name.Length > 10)
            {
                return this.Error("Name should be between 2 and 10.");
            }
            var userId = this.GetUserId();

            input.OwnerId = userId;
            input.CreateOn = DateTime.UtcNow;


            this.repositoryService.Create(input);
           return this.Redirect("/");
        }
    }
}