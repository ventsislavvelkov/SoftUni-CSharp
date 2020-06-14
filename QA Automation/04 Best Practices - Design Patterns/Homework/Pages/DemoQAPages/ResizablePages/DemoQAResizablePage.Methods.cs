using OpenQA.Selenium;
using Homework.Pages.DemoQAPages.DemoQAPage;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQAResizablePage : DemoQaStaticElements
    {
        public DemoQAResizablePage(IWebDriver driver)
            :base(driver)
        {

        }

        public override string Url => "http://www.demoqa.com/resizable";

        public string GetHeightOnResizableElement()
        {
            return ResizableElement.GetCssValue("height");
        }

        public string GetWidthOnResizableElement()
        {
            return ResizableElement.GetCssValue("width");
        }
    }
}
