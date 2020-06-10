using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Homework.Pages
{
   public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Builder = new Actions(Driver);
        }
        public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; private set; }

        public Actions Builder { get; private set; }

        public IWebElement ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true)", element);

            return element;
        }
    }
}
