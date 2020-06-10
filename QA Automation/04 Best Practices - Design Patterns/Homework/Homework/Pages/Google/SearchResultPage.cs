using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Homework.Pages.Google
{
    public class SearchResultPage :BasePage
    {
        public SearchResultPage(IWebDriver driver)
            : base(driver)
        {

        }

        public List<IWebElement> Results => Driver.FindElements(By.XPath("//div[@id='search']//h3")).ToList();

        public HomePage ClickOnFirstResult()
        {
            Results[0].Click();
            return new HomePage(Driver);
        }
    }
}
