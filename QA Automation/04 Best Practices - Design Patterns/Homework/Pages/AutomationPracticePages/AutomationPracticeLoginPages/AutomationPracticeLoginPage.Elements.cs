using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework.Pages.AutomationPracticePages
{
    public partial class AutomationPracticeLoginPage
    {
        public IWebElement EmailTextBox => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='email_create']")));

        public IWebElement CreateAccountButton => Driver.FindElement(By.XPath("//button[@id='SubmitCreate']"));
    }
}
