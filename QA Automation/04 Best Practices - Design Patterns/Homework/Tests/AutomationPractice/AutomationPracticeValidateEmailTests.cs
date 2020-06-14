using NUnit.Framework;
using Homework.Pages.AutomationPracticePages;

namespace Homework.Tests.AutomationPractice
{
    [TestFixture]
    public class AutomationPracticeValidateEmailTests : BaseTest
    {
        private AutomationPracticeHomePage _automationPracticeHomePage;
        private AutomationPracticeLoginPage _automationPracticeLoginPage;
        private AutomationPracticeRegFormPage _automationPracticeRegFormPage;

        [SetUp]
        public void SetUp()
        {
            Initiate();
            
            _automationPracticeHomePage = new AutomationPracticeHomePage(Driver);
            _automationPracticeHomePage.NavigateTo();
            _automationPracticeLoginPage = new AutomationPracticeLoginPage(Driver);
            _automationPracticeRegFormPage = new AutomationPracticeRegFormPage(Driver);
        }

        [Test]
        public void ValidateEmailInRegistrationForm_When_GoToRegister()
        {
            //Arrange
            var regMail = "veo5455@gmail.com";

            //Act
            _automationPracticeHomePage.SignInButton.Click();
            _automationPracticeLoginPage.EmailTextBox.SendKeys(regMail);
            _automationPracticeLoginPage.CreateAccountButton.Click();

            //Assert
            _automationPracticeRegFormPage.AssertValidateEmail(regMail);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
