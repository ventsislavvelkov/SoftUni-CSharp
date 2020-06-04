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

        public string email = "asrtd7654547@abv.bg";

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

            var radioButton = _wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='id_gender1']")));
            radioButton.Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys("Ivan");

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys("Ivanov");

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys("99884411");

            var dateDD = _driver.FindElement(By.Id("days"));
            var date = new SelectElement(dateDD);
            date.SelectByValue("11");
             
            var monthDD = _driver.FindElement(By.Id("months"));
            var months = new SelectElement(monthDD);
            months.SelectByValue("5");

            var yearDD = _driver.FindElement(By.Id("years"));
            var years = new SelectElement(yearDD);
            years.SelectByValue("2010");

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.SendKeys("Ivan");

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys("Ivanov");

            var company = _driver.FindElement(By.Id("company"));
            company.SendKeys("Smart");

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys("ul Ivan Ivanov 50");

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys("Sofia");

            var state = _driver.FindElement(By.XPath("//*[@id='id_state']/option[6]"));
            state.Click();

            var postalCode = _driver.FindElement(By.Id("postcode"));
            postalCode.SendKeys("00000");

            var additionalInformation = _driver.FindElement(By.Id("other"));
            additionalInformation.SendKeys("I like this website!");

            var homePhone = _driver.FindElement(By.Id("phone"));
            homePhone.SendKeys("");

            var mobilePhone = _driver.FindElement(By.Id("phone_mobile"));
            mobilePhone.SendKeys("");

            var AssignAddress = _driver.FindElement(By.Id("alias"));
            AssignAddress.SendKeys("ul Ivan Ivanov 50");

            var submitRegistration = _driver.FindElement(By.Id("submitAccount"));

            submitRegistration.Click();

            var checkErrorMessage = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"))).Text;

            Assert.AreEqual("You must register at least one phone number.", checkErrorMessage);

        }

        [Test]
        public void CreateAnAccountWithoutPostCode()
        {
            GoToPageCreateAccount();

            var radioButton = _wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='id_gender1']")));
            radioButton.Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys("Ivan");

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys("Ivanov");

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys("99884411");

            var dateDD = _driver.FindElement(By.Id("days"));
            var date = new SelectElement(dateDD);
            date.SelectByValue("11");

            var monthDD = _driver.FindElement(By.Id("months"));
            var months = new SelectElement(monthDD);
            months.SelectByValue("5");

            var yearDD = _driver.FindElement(By.Id("years"));
            var years = new SelectElement(yearDD);
            years.SelectByValue("2010");

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.SendKeys("Ivan");

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys("Ivanov");

            var company = _driver.FindElement(By.Id("company"));
            company.SendKeys("Smart");

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys("ul Ivan Ivanov 50");

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys("Sofia");

            var state = _driver.FindElement(By.XPath("//*[@id='id_state']/option[6]"));
            state.Click();

            var postalCode = _driver.FindElement(By.Id("postcode"));
            postalCode.SendKeys("");

            var additionalInformation = _driver.FindElement(By.Id("other"));
            additionalInformation.SendKeys("I like this website!");

            var homePhone = _driver.FindElement(By.Id("phone"));
            homePhone.SendKeys("0888888888");

            var mobilePhone = _driver.FindElement(By.Id("phone_mobile"));
            mobilePhone.SendKeys("08888888888");

            var AssignAddress = _driver.FindElement(By.Id("alias"));
            AssignAddress.SendKeys("ul Ivan Ivanov 50");

            var submitRegistration = _driver.FindElement(By.Id("submitAccount"));

            submitRegistration.Click();

            var checkErrorMessage = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"))).Text;

            Assert.AreEqual("The Zip/Postal code you've entered is invalid. It must follow this format: 00000", checkErrorMessage);
        }

        [Test]
        public void CreateAnAccountWithoutFirstName()
        {
            GoToPageCreateAccount();

            var radioButton = _wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='id_gender1']")));
            radioButton.Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys("");

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys("Ivanov");

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys("99884411");

            var dateDD = _driver.FindElement(By.Id("days"));
            var date = new SelectElement(dateDD);
            date.SelectByValue("11");

            var monthDD = _driver.FindElement(By.Id("months"));
            var months = new SelectElement(monthDD);
            months.SelectByValue("5");

            var yearDD = _driver.FindElement(By.Id("years"));
            var years = new SelectElement(yearDD);
            years.SelectByValue("2010");

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.SendKeys("");

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys("Ivanov");

            var company = _driver.FindElement(By.Id("company"));
            company.SendKeys("Smart");

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys("ul Ivan Ivanov 50");

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys("Sofia");

            var state = _driver.FindElement(By.XPath("//*[@id='id_state']/option[6]"));
            state.Click();

            var postalCode = _driver.FindElement(By.Id("postcode"));
            postalCode.SendKeys("000000");

            var additionalInformation = _driver.FindElement(By.Id("other"));
            additionalInformation.SendKeys("I like this website!");

            var homePhone = _driver.FindElement(By.Id("phone"));
            homePhone.SendKeys("0888888888");

            var mobilePhone = _driver.FindElement(By.Id("phone_mobile"));
            mobilePhone.SendKeys("08888888888");

            var AssignAddress = _driver.FindElement(By.Id("alias"));
            AssignAddress.SendKeys("ul Ivan Ivanov 50");

            var submitRegistration = _driver.FindElement(By.Id("submitAccount"));

            submitRegistration.Click();

            var checkErrorMessage = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"))).Text;

            Assert.AreEqual("firstname is required.", checkErrorMessage);
        }

        [Test]
        public void CreateAnAccountWithoutLastName()
        {
            GoToPageCreateAccount();

            var radioButton = _wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='id_gender1']")));
            radioButton.Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys("Ivan");

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys("");

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys("99884411");

            var dateDD = _driver.FindElement(By.Id("days"));
            var date = new SelectElement(dateDD);
            date.SelectByValue("11");

            var monthDD = _driver.FindElement(By.Id("months"));
            var months = new SelectElement(monthDD);
            months.SelectByValue("5");

            var yearDD = _driver.FindElement(By.Id("years"));
            var years = new SelectElement(yearDD);
            years.SelectByValue("2010");

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.SendKeys("Ivan");

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys("");

            var company = _driver.FindElement(By.Id("company"));
            company.SendKeys("Smart");

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys("ul Ivan Ivanov 50");

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys("Sofia");

            var state = _driver.FindElement(By.XPath("//*[@id='id_state']/option[6]"));
            state.Click();

            var postalCode = _driver.FindElement(By.Id("postcode"));
            postalCode.SendKeys("00000");

            var additionalInformation = _driver.FindElement(By.Id("other"));
            additionalInformation.SendKeys("I like this website!");

            var homePhone = _driver.FindElement(By.Id("phone"));
            homePhone.SendKeys("0888888888");

            var mobilePhone = _driver.FindElement(By.Id("phone_mobile"));
            mobilePhone.SendKeys("08888888888");

            var AssignAddress = _driver.FindElement(By.Id("alias"));
            AssignAddress.SendKeys("ul Ivan Ivanov 50");

            var submitRegistration = _driver.FindElement(By.Id("submitAccount"));

            submitRegistration.Click();

            var checkErrorMessage = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"))).Text;

            Assert.AreEqual("lastname is required.", checkErrorMessage);
        }

        [Test]
        public void CreateAnAccountWithoutPassword()
        {
            GoToPageCreateAccount();

            var radioButton = _wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='id_gender1']")));
            radioButton.Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys("Ivan");

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys("Ivanov");

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys("");

            var dateDD = _driver.FindElement(By.Id("days"));
            var date = new SelectElement(dateDD);
            date.SelectByValue("11");

            var monthDD = _driver.FindElement(By.Id("months"));
            var months = new SelectElement(monthDD);
            months.SelectByValue("5");

            var yearDD = _driver.FindElement(By.Id("years"));
            var years = new SelectElement(yearDD);
            years.SelectByValue("2010");

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.SendKeys("Ivan");

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys("Ivanov");

            var company = _driver.FindElement(By.Id("company"));
            company.SendKeys("Smart");

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys("ul Ivan Ivanov 50");

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys("Sofia");

            var state = _driver.FindElement(By.XPath("//*[@id='id_state']/option[6]"));
            state.Click();

            var postalCode = _driver.FindElement(By.Id("postcode"));
            postalCode.SendKeys("00000");

            var additionalInformation = _driver.FindElement(By.Id("other"));
            additionalInformation.SendKeys("I like this website!");

            var homePhone = _driver.FindElement(By.Id("phone"));
            homePhone.SendKeys("0888888888");

            var mobilePhone = _driver.FindElement(By.Id("phone_mobile"));
            mobilePhone.SendKeys("08888888888");

            var AssignAddress = _driver.FindElement(By.Id("alias"));
            AssignAddress.SendKeys("ul Ivan Ivanov 50");

            var submitRegistration = _driver.FindElement(By.Id("submitAccount"));

            submitRegistration.Click();

            var checkErrorMessage = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"))).Text;

            Assert.AreEqual("passwd is required.", checkErrorMessage);
        }
    }
}