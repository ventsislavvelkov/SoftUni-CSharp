using OpenQA.Selenium;

namespace Homework.Pages.SoftUniPages
{
    public partial class SoftUniQAAutomationCoursePage : BasePage
    {
        public SoftUniQAAutomationCoursePage(IWebDriver driver)
            : base(driver)
        {

        }

        public override string Url => "https://softuni.bg/trainings/2550/qa-automation-may-2020";
    }
}
