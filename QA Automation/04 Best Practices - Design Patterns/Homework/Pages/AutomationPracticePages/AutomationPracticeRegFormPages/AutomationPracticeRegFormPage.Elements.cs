using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework.Pages.AutomationPracticePages
{
    public partial class AutomationPracticeRegFormPage
    {

        public IWebElement FirstName => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("customer_firstname")));

        public IWebElement LastName => Driver.FindElement(By.Id("customer_lastname"));

        public IWebElement Password => Driver.FindElement(By.Id("passwd"));

        public IWebElement Address => Driver.FindElement(By.Id("address1"));

        public IWebElement City => Driver.FindElement(By.Id("city"));

        public IWebElement ZipCode => Driver.FindElement(By.Id("postcode"));

        public IWebElement MobilePhone => Driver.FindElement(By.Id("phone_mobile"));

        public IWebElement RegisterButton => Driver.FindElement(By.XPath("//span[text()='Register']"));

        public IWebElement ErrorMessage => Driver.FindElement(By.XPath("//div[@class='alert alert-danger']//li"));
    }
}
