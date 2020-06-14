using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework.Pages.SoftUniPages
{
    public partial class SoftUniQAAutomationCoursePage
    {
        public IWebElement QACourseHeading => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header[@class='lead-header image-background']//h1")));
    }
}
