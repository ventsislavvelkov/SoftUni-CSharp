using OpenQA.Selenium;

namespace Homework.Pages.SoftUniPages
{
    public partial class SoftUniHomePage : BasePage
    {
        public SoftUniHomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public override string Url => "https://softuni.bg/";
    }
}
