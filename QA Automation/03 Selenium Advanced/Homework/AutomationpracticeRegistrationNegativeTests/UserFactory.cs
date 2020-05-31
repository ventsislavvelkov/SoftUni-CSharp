using System;
using AutoFixture;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace AutomationPracticeRegistrationNegativeTests
{
   public static class UserFactory
    {
        public static RegistrationUser CreateValidUser()
        {
            var fixture = new Fixture();
            var dateTime = fixture.Create<DateTime>();

            return new RegistrationUser
            {
                FirstName = fixture.Create<string>(),
                LastName = fixture.Create<string>(),
                Year = dateTime.Year.ToString(),
                Month = dateTime.Month.ToString(),
                Date = dateTime.Date.ToString(),
                Password = fixture.Create<string>(),
                Gender = Gender.Male.ToString(),
                PostCode = fixture.Create<int>().ToString(),
                
            };
        }
    }
}
