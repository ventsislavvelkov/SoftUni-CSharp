using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Pages.GooglePages
{
    public partial class GoogleSeleniumSearchResultsPage
    {
        public List<IWebElement> Results => Driver.FindElements(By.XPath("//div[@id='search']//h3")).ToList();
    }
}
