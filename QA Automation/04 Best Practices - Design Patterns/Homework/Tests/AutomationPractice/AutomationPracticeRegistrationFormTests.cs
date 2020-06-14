using NUnit.Framework;
using Homework.Factories;
using Homework.Models;
using Homework.Pages.AutomationPracticePages;

namespace Homework.Tests.AutomationPractice
{
    [TestFixture]
    public class AutomationPracticeRegistrationFormTests : BaseTest
    {
        private AutomationPracticeHomePage _automationPracticeHomePage;
        private AutomationPracticeLoginPage _automationPracticeLoginPage;
        private string _regMail;
        private AutomationPracticeRegFormPage _automationPracticeRegFormPage;
        private PracticeUserRegModel _user;

        [SetUp]
        public void SetUp()
        {
            Initiate();
            
            _automationPracticeHomePage = new AutomationPracticeHomePage(Driver);
            _automationPracticeHomePage.NavigateTo();
            _automationPracticeHomePage.SignInButton.Click();
            _automationPracticeLoginPage = new AutomationPracticeLoginPage(Driver);
            _regMail = "veo5455@gmail.com";
            _automationPracticeLoginPage.EmailTextBox.SendKeys(_regMail);
            _automationPracticeLoginPage.CreateAccountButton.Click();
            _automationPracticeRegFormPage = new AutomationPracticeRegFormPage(Driver);
            _user = UserRegFactory.Create();
        }

        [Test]
        public void InvalidZipCode_When_RegisterUser()
        {
            //Arrange
            _user.ZipCode = "565";
            var expectedErrorMessage = "The Zip/Postal code you've entered is invalid. It must follow this format: 00000";

            //Act
            _automationPracticeRegFormPage.FillRegForm(_user);

            //Assert
            _automationPracticeRegFormPage.AssertErrorMessage(expectedErrorMessage);
        }

        [Test]
        public void EmptyFirstName_When_RegisterUser()
        {
            //Arrange
            _user.FirstName = string.Empty;
            var expectedErrorMessage = "firstname is required.";

            //Act
            _automationPracticeRegFormPage.FillRegForm(_user);

            //Assert
            _automationPracticeRegFormPage.AssertErrorMessage(expectedErrorMessage);
        }

        [Test]
        public void EmptyLastName_When_RegisterUser()
        {
            //Arrange
            _user.LastName = string.Empty;
            var expectedErrorMessage = "lastname is required.";

            //Act
            _automationPracticeRegFormPage.FillRegForm(_user);

            //Assert
            _automationPracticeRegFormPage.AssertErrorMessage(expectedErrorMessage);
        }

        [Test]
        public void EmptyAddress_When_RegisterUser()
        {
            //Arrange
            _user.Address = string.Empty;
            var expectedErrorMessage = "address1 is required.";

            //Act
            _automationPracticeRegFormPage.FillRegForm(_user);

            //Assert
            _automationPracticeRegFormPage.AssertErrorMessage(expectedErrorMessage);
        }

        [Test]
        public void EmptyMobilePhone_When_RegisterUser()
        {
            //Arrange
            _user.MobilePhone = string.Empty;
            var expectedErrorMessage = "You must register at least one phone number.";

            //Act
            _automationPracticeRegFormPage.FillRegForm(_user);

            //Assert
            _automationPracticeRegFormPage.AssertErrorMessage(expectedErrorMessage);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
