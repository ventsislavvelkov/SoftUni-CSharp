using Git.ErrorMessages;
using Git.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;

        public CommitsController(ICommitsService commitsService)
        {
            this.commitsService = commitsService;
        }
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            var viewModel = this.commitsService.All(userId);
            return this.View(viewModel);
        }
   
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var viewModel = this.commitsService.GetRepositoryNameAndId(id);
            return this.View(viewModel);
        }
        [HttpPost]
        public HttpResponse Create(string id , string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (string.IsNullOrEmpty(description) || description.Length<5)
            {
                return this.Error(ErrorMessage.InvalidCommitDescription);
            }
            var userId = this.GetUserId();
            this.commitsService.CreateCommit(id, description, userId);
            return this.Redirect("/Repositories/All");
        }
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            this.commitsService.DeleteCommit(id,userId);
            return this.Redirect("/Commits/All");
        }
    }
}
