using OpenQA.Selenium;

namespace Homework.Pages.AutomationPracticePages
{
    public partial class AutomationPracticeHomePage : BasePage
    {
        public AutomationPracticeHomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public override string Url => "http://automationpractice.com/index.php";

    }
}
