using OpenQA.Selenium;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQASelectablePage
    {
        public IWebElement FirstElement => Driver.FindElements(By.XPath("//ul[@id='verticalListContainer']//li"))[0];

        public IWebElement SecondElement => Driver.FindElements(By.XPath("//ul[@id='verticalListContainer']//li"))[1];
    }
}
