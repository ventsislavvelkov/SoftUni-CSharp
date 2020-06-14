using Homework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Factories
{
    public static class UserRegFactory
    {
        public static PracticeUserRegModel Create()
        {
            return new PracticeUserRegModel
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Password = "ivo1231",
                Address = "Po Box 564",
                City = "sofia",
                State = "Florida",
                ZipCode = "22566",
                MobilePhone = "1234567892"
            };
        }
    }
}
