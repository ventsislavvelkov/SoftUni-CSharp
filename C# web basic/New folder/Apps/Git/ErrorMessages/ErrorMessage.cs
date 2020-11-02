using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ErrorMessages
{
   public static class ErrorMessage
    {
        //Login ->
        public static readonly string InvalidUsernameAndPassword = "Invalid username or password";

        //Register ->
        //Username
        public static readonly string InvalidUsername = "Username should be between 5 and 20 characters.";
        public static readonly string TakenUsername = "Username already taken.";
                
        //Email
        public static readonly string InvalidEmail = "Email should be valid.";
        public static readonly string TakenEmail = "Email already taken.";
             
        //Password
        public static readonly string InvalidPassword = "Password should be between 6 and 20 characters.";
        public static readonly string NotMatchPassword = "Password doesn't match.";

        //Create Repository
        public static readonly string InvalidRepositoryName = "Name should be between 3 and 10 characters.";

        //Create Commit
        public static readonly string InvalidCommitDescription = "Description should be more than 5 characters.";

    }
}
