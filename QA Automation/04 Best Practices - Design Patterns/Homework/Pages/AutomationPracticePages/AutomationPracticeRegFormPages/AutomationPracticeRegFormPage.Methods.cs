using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Homework.Models;

namespace Homework.Pages.AutomationPracticePages
{
    public partial class AutomationPracticeRegFormPage : BasePage
    {
        public AutomationPracticeRegFormPage(IWebDriver driver)
            :base(driver)
        {

        }

        public override string Url => "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";

        public void SetState(string stateName)
        {
            var state = Wait.Until(d => d.FindElement(By.XPath($"//select[@id = 'id_state']//*[text()='{stateName}']")));
            var selectElement = new SelectElement(Driver.FindElement(By.Id("id_state")));
            selectElement.SelectByText(stateName);
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        public string ValidateMailInRegForm(string mail)
        {
            Wait.Until<bool>(d => d.FindElement(By.Id("email")).GetProperty("value") == mail);
            return Driver.FindElement(By.Id("email")).GetProperty("value");
        }

        public void FillRegForm(PracticeUserRegModel user)
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
