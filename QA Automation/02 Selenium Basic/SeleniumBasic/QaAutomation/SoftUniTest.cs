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
          //  _driver.Quit();
        }

        [Test]

        public void HomePageNavigationBar()
        {
            var menuBtnClick = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[2]/ul/li[1]/a/span/i")));
            menuBtnClick.Click();           
            
            var coursesBtnClick = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/a/span")));
            coursesBtnClick.Click();

            var courseQaAutomationClick = _wait.Until<IWebElement>(d =>
                d.FindElement(By.CssSelector(
                    "#header-nav > div.toggle-nav.toggle-holder.toggle-active > ul > li.nav-item.dropdown-item.nav-item-active.dropdown-active.open > div > div > div.row.no-margin-offset.courses-and-modules-wrapper > div.col-md-8.open-courses-wrapper.open-courses-background > div > div:nth-child(2) > ul:nth-child(4) > div:nth-child(1) > ul > li > a")));
            courseQaAutomationClick.Click();

            var headingТagH1Contains = _wait.Until<IWebElement>(d =>
                d.FindElement(By.XPath("/html/body/div[2]/header/h1")));

            Assert.AreEqual("QA Automation - май 2020", headingТagH1Contains);
        }


    }
}
