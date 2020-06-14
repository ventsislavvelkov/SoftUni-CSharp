using OpenQA.Selenium;
using Homework.Pages.DemoQAPages.DemoQAPage;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQADroppablePage : DemoQaStaticElements
    {
        public DemoQADroppablePage(IWebDriver driver)
            :base(driver)
        {

        }

        public override string Url => "http://www.demoqa.com/droppable";

        public string GetBackgroundColorOnTargetElement()
        {
            return DropElement.GetCssValue("background-color");
        }

        public string GetTextInTargetElement()
        {
            return DropElement.FindElement(By.XPath("//p[1]")).Text;
        }

        public string GetTextInSourceElement()
        {
            return DragElement.Text;
        }


    }
}
