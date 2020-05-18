using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeRegistration
{
    public class AutomationPracticeTest
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        private string email = "veloman@abv.bg";

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            {
                Url = "http://automationpractice.com/index.php"
            };

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
        }

        [TearDown]
        public void TearDown()
        {
           _driver.Quit();
        }

        [Test]
        public void CreateAccount()
        {
            var clickSignInBtn = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a")));

            clickSignInBtn.Click();

            var createAccount = _wait.Until<IWebElement>(d=>
                d.FindElement(By.XPath("//*[@id=\"email_create\"]")));

            createAccount.SendKeys(email);

            var clickCreateAnAccountBtn = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id=\"SubmitCreate\"]")));

            clickCreateAnAccountBtn.Click();

            var checkMailIfIsCorrect =  _wait.Until<bool>(d => 
                d.FindElement(By.Id("email")).GetProperty("value") == email);

            var mailField = _driver.FindElement(By.Id("email"));
            var curValue = mailField.GetProperty("value");

            Assert.AreEqual(email, curValue);

        }
    }
}
