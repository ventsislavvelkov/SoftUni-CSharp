using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework.Pages.AutomationPractice
{
    public class LoginPage :BasePage
    {
        public LoginPage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement EmailTextBox => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='email_create']")));

        public IWebElement CreateAccountButton => Driver.FindElement(By.XPath("//button[@id='SubmitCreate']"));

        public RegistrationFormPage NavigateToRegistrationForm(string mail)
        {
            EmailTextBox.SendKeys(mail);
            CreateAccountButton.Click();

            return new RegistrationFormPage(Driver);
        }
    }
}
