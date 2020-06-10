using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Homework.Pages.AutomationPractice
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement SignInButton => Driver.FindElement(By.XPath("//a[@class='login']"));

        public LoginPage NavigateToLoginPage()
        {
            SignInButton.Click();

            return new LoginPage(Driver);
        }
    }
}
