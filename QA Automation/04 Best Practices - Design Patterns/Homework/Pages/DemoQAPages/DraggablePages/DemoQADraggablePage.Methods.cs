using OpenQA.Selenium;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQADraggablePage
    {

        public DemoQADraggablePage(IWebDriver driver)
            : base(driver)
        {

        }

        public override string Url => "http://www.demoqa.com/dragabble";

        public string GetDraggableElementVerticalPosition()
        {
            return DragElement.GetCssValue("Left");
        }

        public string GetDraggableElementHorizontalPosition()
        {
            return DragElement.GetCssValue("Top");
        }
    }
}
