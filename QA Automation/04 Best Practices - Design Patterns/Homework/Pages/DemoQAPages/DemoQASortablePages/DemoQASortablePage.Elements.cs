using OpenQA.Selenium;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQASortablePage
    {

        public IWebElement FirstElement => Driver.FindElements(By.XPath("//div[@class='vertical-list-container mt-4']//div[@class='list-group-item list-group-item-action']"))[0];

        public IWebElement SecondElement => Driver.FindElements(By.XPath("//div[@class='vertical-list-container mt-4']//div[@class='list-group-item list-group-item-action']"))[1];
    }
}
