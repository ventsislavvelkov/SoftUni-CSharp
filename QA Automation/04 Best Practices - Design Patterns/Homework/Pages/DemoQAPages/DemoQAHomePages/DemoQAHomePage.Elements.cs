using OpenQA.Selenium;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQAHomePage
    {

        public IWebElement MenuInteractionButton => Driver.FindElement(By.XPath("//h5[normalize-space(text())='Interactions']//ancestor::div[@class='card mt-4 top-card']"));


    }
}
