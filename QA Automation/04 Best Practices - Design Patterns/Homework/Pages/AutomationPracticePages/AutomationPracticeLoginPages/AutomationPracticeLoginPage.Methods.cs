using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework.Pages.AutomationPracticePages
{
    public partial class AutomationPracticeLoginPage :BasePage
    {
        public AutomationPracticeLoginPage(IWebDriver driver)
            :base(driver)
        {

        }

        public override string Url => "http://automationpractice.com/index.php?controller=authentication&back=my-account";
    }
}
