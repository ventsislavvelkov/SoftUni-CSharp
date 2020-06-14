using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Homework.Utilities;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQADroppablePage
    {
    
        public IWebElement DragElement
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@classname='Top-Ad']")));
                var dragElement = Wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("draggable")));
                Driver.ScroolTo(dragElement);
                return dragElement;
            }
        }

        public IWebElement DropElement => Wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("droppable")));

    }
}
