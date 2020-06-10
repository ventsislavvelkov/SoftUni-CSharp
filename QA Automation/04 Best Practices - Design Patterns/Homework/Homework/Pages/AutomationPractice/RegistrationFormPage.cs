using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework.Pages.AutomationPractice
{
   public  class RegistrationFormPage :BasePage
    {
        public RegistrationFormPage(IWebDriver driver)
           : base(driver)
        {

        }

        public IWebElement FirstName => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("customer_firstname")));

        public IWebElement LastName => Driver.FindElement(By.Id("customer_lastname"));

        public IWebElement Password => Driver.FindElement(By.Id("passwd"));

        public IWebElement Address => Driver.FindElement(By.Id("address1"));

        public IWebElement City => Driver.FindElement(By.Id("city"));

        public IWebElement ZipCode => Driver.FindElement(By.Id("postcode"));

        public IWebElement MobilePhone => Driver.FindElement(By.Id("phone_mobile"));

        public IWebElement RegisterButton => Driver.FindElement(By.XPath("//span[text()='Register']"));

        public IWebElement ErrorMessage => Driver.FindElement(By.XPath("//div[@class='alert alert-danger']//li"));

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        public string ValidateMailInRegForm(string mail)
        {
            Wait.Until<bool>(d => d.FindElement(By.Id("email")).GetProperty("value") == mail);
            return Driver.FindElement(By.Id("email")).GetProperty("value");
        }

        public void SetState(string stateName)
        {
            var state = Wait.Until(d => d.FindElement(By.XPath($"//select[@id = 'id_state']//*[text()='{stateName}']")));
            var selectElement = new SelectElement(Driver.FindElement(By.Id("id_state")));
            selectElement.SelectByText(stateName);
        }

        public void FillRegForm(AutomationPracticeUserRegModel user)
        {
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Password.SendKeys(user.Password);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            SetState(user.State);
            ZipCode.SendKeys(user.ZipCode);
            MobilePhone.SendKeys(user.MobilePhone);
            RegisterButton.Click();
        }
    }
}
