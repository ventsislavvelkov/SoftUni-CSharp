using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Pages.Google
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement SearchField => Driver.FindElement(By.XPath("//input[@name='q']"));

        public SearchResultPage PerformSearch(string searchFor)
        {
            SearchField.SendKeys("Selenium");
            SearchField.SendKeys(Keys.Return);

            return new SearchResultPage(Driver);
        }
    }
}
