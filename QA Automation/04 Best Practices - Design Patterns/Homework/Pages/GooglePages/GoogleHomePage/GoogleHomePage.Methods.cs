using OpenQA.Selenium;

namespace Homework.Pages.GooglePages
{
    public partial class GoogleHomePage : BasePage
    {
        public GoogleHomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public override string Url => "https://google.bg";

    }
}
