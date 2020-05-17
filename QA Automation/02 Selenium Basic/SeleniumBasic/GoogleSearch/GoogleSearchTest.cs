using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GoogleSearch
{
    [TestFixture]
    public class GoogleSearchTest
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Url = "http://www.google.com";

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]

        public void SearchSeleniumWebsite()
        {
            var mainPageSearchBox = _wait.Until<IWebElement>(d=>
                d.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input")));

            mainPageSearchBox.SendKeys("selenium");

            var mainPageSearchBtn = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[3]/center/input[1]")));

            mainPageSearchBtn.Click();

            var firstResult = _wait.Until<IWebElement>(d => 
                d.FindElement(By.XPath("//*[@id='rso']/div[1]//a")));
           
            firstResult.Click();
            
        }

        public void checkHomePageTitle()
        {
            var seleniumTitle = _driver.Title;

            Assert.AreEqual("Selenium - Web Browser Automation", seleniumTitle);
        }

        public void checkHomePageURL()
        {
            var seleniumTitle = _driver.Url;

            Assert.AreEqual("http://www.seleniumhq.org", seleniumTitle);
        }


    }
}
