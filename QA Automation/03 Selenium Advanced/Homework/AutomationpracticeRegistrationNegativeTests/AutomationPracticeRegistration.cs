using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeRegistrationNegativeTests
{
    public class AutomationPracticeRegistration
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public string email = "asrtd7687@abv.bg";

        [SetUp]
        public void Setup()
        {

             _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
             _driver.Manage().Window.Maximize();
             _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
 
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));

        }

        [TearDown]
        public void TearDown()
        { 
            _driver.Quit();
        }

        public void GoToPageCreateAccount()
        {
            var clickSignInBtn = _wait.Until(c =>
                c.FindElement(By.ClassName("login")));
            clickSignInBtn.Click();

            var createAccount = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("email_create")));
            createAccount.SendKeys(email);

            var clickCreateAnAccountBtn = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("SubmitCreate")));

            clickCreateAnAccountBtn.Click();
        }

        [Test]
        public void CreateAnAccountWithoutPhoneNumber()
        {
            GoToPageCreateAccount();

            var firstName = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("customer_firstname")));
            firstName.SendKeys("Ivan");

            var lastName = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("customer_lastname")));
            lastName.SendKeys("Ivanov");

            var password = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("passwd")));
            password.SendKeys("99884411");

            var address = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("address1")));
            address.SendKeys("ul Ivan Ivanov 50");

            var city = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("city")));
            city.SendKeys("Sofia");

            var state = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id='id_state']/option[6]")));
            state.Click();

            var postalCode = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("postcode")));
            postalCode.SendKeys("00000");

            var mobilePhone = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("phone_mobile")));
            mobilePhone.SendKeys("");


            var submitRegistration = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("submitAccount")));

            submitRegistration.Click();


            var checkErrorMessage = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"))).Text;

            Assert.AreEqual("You must register at least one phone number.", checkErrorMessage);

        }

        [Test]
        public void CreateAnAccountWithoutPostCode()
        {
            GoToPageCreateAccount();

            var firstName = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("customer_firstname")));
            firstName.SendKeys("Ivan");

            var lastName = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("customer_lastname")));
            lastName.SendKeys("Ivanov");

            var password = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("passwd")));
            password.SendKeys("99884411");

            var address = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("address1")));
            address.SendKeys("ul Ivan Ivanov 50");

            var city = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("city")));
            city.SendKeys("Sofia");

            var state = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id='id_state']/option[6]")));
            state.Click();

            var postalCode = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("postcode")));
            postalCode.SendKeys("");

            var mobilePhone = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("phone_mobile")));
            mobilePhone.SendKeys("00359889889889");


            var submitRegistration = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("submitAccount")));

            submitRegistration.Click();


            var checkErrorMessage = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"))).Text;

            Assert.AreEqual("The Zip/Postal code you've entered is invalid. It must follow this format: 00000", checkErrorMessage);

        }

        [Test]
        public void CreateAnAccountWithoutFirstName()
        {
            GoToPageCreateAccount();

            var firstName = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("customer_firstname")));
            firstName.SendKeys("");

            var lastName = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("customer_lastname")));
            lastName.SendKeys("Ivanov");

            var password = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("passwd")));
            password.SendKeys("99884411");

            var address = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("address1")));
            address.SendKeys("ul Ivan Ivanov 50");

            var city = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("city")));
            city.SendKeys("Sofia");

            var state = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id='id_state']/option[6]")));
            state.Click();

            var postalCode = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("postcode")));
            postalCode.SendKeys("00000");

            var mobilePhone = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("phone_mobile")));
            mobilePhone.SendKeys("00359889889889");


            var submitRegistration = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("submitAccount")));

            submitRegistration.Click();


            var checkErrorMessage = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"))).Text;

            Assert.AreEqual("firstname is required.", checkErrorMessage);

        }

        [Test]
        public void CreateAnAccountWithoutLastName()
        {
            GoToPageCreateAccount();

            var firstName = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("customer_firstname")));
            firstName.SendKeys("Ivan");

            var lastName = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("customer_lastname")));
            lastName.SendKeys("");

            var password = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("passwd")));
            password.SendKeys("99884411");

            var address = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("address1")));
            address.SendKeys("ul Ivan Ivanov 50");

            var city = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("city")));
            city.SendKeys("Sofia");

            var state = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id='id_state']/option[6]")));
            state.Click();

            var postalCode = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("postcode")));
            postalCode.SendKeys("00000");

            var mobilePhone = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("phone_mobile")));
            mobilePhone.SendKeys("00359889889889");


            var submitRegistration = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("submitAccount")));

            submitRegistration.Click();


            var checkErrorMessage = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"))).Text;

            Assert.AreEqual("lastname is required.", checkErrorMessage);

        }

        [Test]
        public void CreateAnAccountWithoutPassword()
        {
            GoToPageCreateAccount();

            var firstName = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("customer_firstname")));
            firstName.SendKeys("Ivan");

            var lastName = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("customer_lastname")));
            lastName.SendKeys("ivanov");

            var password = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("passwd")));
            password.SendKeys("");

            var address = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("address1")));
            address.SendKeys("ul Ivan Ivanov 50");

            var city = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("city")));
            city.SendKeys("Sofia");

            var state = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id='id_state']/option[6]")));
            state.Click();

            var postalCode = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("postcode")));
            postalCode.SendKeys("00000");

            var mobilePhone = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("phone_mobile")));
            mobilePhone.SendKeys("00359889889889");


            var submitRegistration = _wait.Until<IWebElement>(d =>
                d.FindElement(By.Id("submitAccount")));

            submitRegistration.Click();


            var checkErrorMessage = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"))).Text;

            Assert.AreEqual("passwd is required.", checkErrorMessage);

        }
    }
}