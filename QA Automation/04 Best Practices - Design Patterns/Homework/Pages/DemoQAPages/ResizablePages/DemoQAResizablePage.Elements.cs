using OpenQA.Selenium;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQAResizablePage
    {
        public IWebElement ResizableElement => Driver.FindElement(By.Id("resizable"));

        public IWebElement ResizableHandler => Driver.FindElement(By.XPath("//div[@id='resizable']//span"));

    }
}
