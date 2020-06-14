using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework.Pages.SoftUniPages
{
    public partial class SoftUniQACoursePage
    {
        public IWebElement QACourseAutomationButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/trainings/2550/qa-automation-may-2020']")));
    }
}
