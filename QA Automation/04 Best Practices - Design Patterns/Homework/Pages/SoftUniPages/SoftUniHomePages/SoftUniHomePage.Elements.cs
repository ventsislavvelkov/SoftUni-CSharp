using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Pages.SoftUniPages
{
    public partial class SoftUniHomePage
    {
        public IWebElement MenuTrainingButton => Driver.FindElement(By.XPath("//span[text()='Обучения']"));

        public List<IWebElement> ActiveCourses => Driver.FindElements(By.XPath("//div[@class='my-collapsible']")).ToList();

        public IWebElement MenuQACourseButton => Driver.FindElement(By.LinkText("Quality Assurance - октомври 2019"));
    }
}
