using OpenQA.Selenium;

namespace Homework.Pages.SoftUniPages
{
    public partial class SoftUniQACoursePage : BasePage
    {
        public SoftUniQACoursePage(IWebDriver driver)
            : base(driver)
        {

        }

        public override string Url => "https://softuni.bg/modules/80/quality-assurance-october-2019/1224";
    }
}
