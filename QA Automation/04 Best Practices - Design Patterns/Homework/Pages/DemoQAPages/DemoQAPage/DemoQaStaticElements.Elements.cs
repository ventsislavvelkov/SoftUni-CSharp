using OpenQA.Selenium;
using Homework.Utilities;

namespace Homework.Pages.DemoQAPages.DemoQAPage
{
    public partial class DemoQaStaticElements
    {
        public IWebElement LeftMenu => Driver.FindElement(By.XPath("//div[@class='left-pannel']"));

        public IWebElement SubMenu (string subButtonName)
        {
            var curButton = Wait.Until(l => l.FindElement(By.XPath($".//span[text()='{subButtonName}']")));
            Driver.ScroolTo(curButton);
            return curButton;
        }
    }
}
