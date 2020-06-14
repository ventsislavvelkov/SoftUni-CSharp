using OpenQA.Selenium;

namespace Homework.Pages.SeleniumPages
{
    public partial class SeleniumHomePage : BasePage
    {
        public SeleniumHomePage(IWebDriver driver)
            :base(driver)
        {

        }

        public override string Url => "https://www.selenium.dev/";
    }
}
