using OpenQA.Selenium;
using Homework.Pages.DemoQAPages.DemoQAPage;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQASelectablePage : DemoQaStaticElements
    {
        public DemoQASelectablePage(IWebDriver driver)
            : base(driver)
        {

        }

        public override string Url => "http://www.demoqa.com/selectable";

        public string GetBackgroundColorOnFirstElement()
        {
            return FirstElement.GetCssValue("background-color");
        }

        public string GetBackgroundColorOnSecondElement()
        {
            return SecondElement.GetCssValue("background-color");
        }
    }
}
