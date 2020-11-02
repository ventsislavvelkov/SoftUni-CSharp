using Git.Services;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Git.ViewModels.Users
{
    public class LoginInputModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
        
    }
}