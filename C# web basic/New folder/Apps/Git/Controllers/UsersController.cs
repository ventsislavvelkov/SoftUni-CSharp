using Git.ErrorMessages;
using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }


        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            var userId = this.usersService.GetUserId(username, password);
            if (userId == null)
            {
                this.Error(ErrorMessage.InvalidUsernameAndPassword);
                return this.View();
            }
            this.SignIn(userId);
            return this.Redirect("/Repositories/All");
        }
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            //TODO: Make the message in separeted class
            if (string.IsNullOrEmpty(input.Username) || input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error(ErrorMessage.InvalidUsername);
            }
            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error(ErrorMessage.TakenUsername);
            }
            if (string.IsNullOrEmpty(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error(ErrorMessage.InvalidEmail);
            }
            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error(ErrorMessage.TakenEmail);
            }
            if (string.IsNullOrEmpty(input.Password) || input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error(ErrorMessage.InvalidPassword);
            }
            if (string.IsNullOrEmpty(input.ConfirmPassword) || !(input.Password == input.ConfirmPassword))
            {
                return this.Error(ErrorMessage.NotMatchPassword);
            }
            this.usersService.CreateUser(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }
        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            this.SignOut();
            return this.Redirect("/Users/Login");
        }
    }
}
