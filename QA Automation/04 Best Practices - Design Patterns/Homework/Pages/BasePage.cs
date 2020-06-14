using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Homework.Pages
{
    public abstract class BasePage
    {
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Builder = new Actions(Driver);
        }
        public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; private set; }

        public Actions Builder { get; private set; }

        public virtual string Url { get; }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }
}
