using OpenQA.Selenium;

namespace Homework.Pages.GooglePages
{
    public partial class GoogleHomePage
    {
        public IWebElement SearchField => Driver.FindElement(By.XPath("//input[@name='q']"));
    }
}
