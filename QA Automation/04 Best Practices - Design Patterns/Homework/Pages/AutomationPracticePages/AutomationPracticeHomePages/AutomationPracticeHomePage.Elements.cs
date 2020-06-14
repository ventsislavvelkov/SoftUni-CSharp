using OpenQA.Selenium;

namespace Homework.Pages.AutomationPracticePages
{
    public partial class AutomationPracticeHomePage
    {

        public IWebElement SignInButton => Driver.FindElement(By.XPath("//a[@class='login']"));

    }
}
