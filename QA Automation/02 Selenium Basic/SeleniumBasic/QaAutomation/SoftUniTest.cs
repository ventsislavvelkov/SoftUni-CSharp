using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace QaAutomation
{
    public class SoftUniTest
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            {
                Url = "http://www.softuni.bg"
            };

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void TearDown()
        {
            
            foreach (var window in _driver.WindowHandles)
            {
                _driver.SwitchTo().Window(window);
                _driver.Close();
            }

            _driver.Quit();
        }

        [Test]

        public void HomePageNavigationBar()
        {

            var homePageSearchBtnClick = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id=\"search-icon-container\"]/a/span/i")));
            homePageSearchBtnClick.Click();

            var mainPageSearchBox = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id=\"search-input\"]")));

            mainPageSearchBox.SendKeys("Qa");

            var searchBtnClick = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id=\"search-dropdown\"]/div/form/div[1]/button")));
            searchBtnClick.Click();

            var QaCoursesLink = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id=\"fast-track-instance-results\"]/ul/li[1]/div/a")));
            QaCoursesLink.Click();

            var allOpenPages = _driver.WindowHandles;
            _driver.SwitchTo().Window(allOpenPages[1]);

            var headingТagH1Contains = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("/html/body/div[2]/header/h1"))).Text;

            Assert.AreEqual("QA Automation - май 2020", headingТagH1Contains);
        }
    }
}
