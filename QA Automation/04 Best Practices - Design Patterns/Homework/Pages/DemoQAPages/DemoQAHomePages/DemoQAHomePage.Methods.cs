using OpenQA.Selenium;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQAHomePage : BasePage
    {
        public DemoQAHomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public override string Url => "http://www.demoqa.com/";
    }
}
